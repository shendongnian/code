    namespace TimeTrigger
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static void Run([TimerTrigger("%Schedule%")]TimerInfo myTimer, ILogger log)
            {
                log.LogInformation("11111111111111111111111111111");
                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            }
        }
    }
