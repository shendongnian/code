    [FunctionName("MyFristTriggerFunction")]
    public static void MyFristTriggerFunction(
        [EventHubTrigger("%eventHubName%", Connection = @"EventHubConnectionString")] EventData[] events
        ILogger log)
    {
