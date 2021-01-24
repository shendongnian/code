    public static void Run(TimerInfo myTimer, ILogger log, [ServiceBus("myqueue", Connection = "ServiceBusConnection")] ICollector<string> outputSbQueue)
    {
        string message = $"Service Bus queue messages created at: {DateTime.Now}";
        log.LogInformation(message); 
        outputSbQueue.Add("1 " + message);
        outputSbQueue.Add("2 " + message);
    }
