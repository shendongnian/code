    [FunctionName("TimerTriggerCSharp")]
    public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
    {
        if (myTimer.IsPastDue)
        {
            log.LogInformation("Timer is running late!");
        }
        log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
    }
