    using System;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;
    
    namespace TimeTrigger
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static void Run([TimerTrigger("%Schedule%")]TimerInfo myTimer, ILogger log)
            {
                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            }
        }
    }
