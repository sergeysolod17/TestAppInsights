using System;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TestAppInsights
{
    public static class TestAppInsightsNet6
    {
        [FunctionName("TestAppInsightsNet6")]
        public static void Run([HttpTrigger(AuthorizationLevel.Anonymous, Route = "test")] HttpRequest req, ILogger log)
        {
            try
            {
                TelemetryConfiguration.CreateDefault();
            }
            catch (Exception e)
            {
                log.LogWarning(e.Message);
                log.LogWarning(e.StackTrace);
                throw;
            }

            log.LogInformation($"C# HTTP trigger function executed at: {DateTime.Now}");
        }
    }
}
