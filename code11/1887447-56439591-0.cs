    [FunctionName("MyFunction")]
    public static async Task Run([ServiceBusTrigger("topic", "subscription", Connection = "AzureServiceBusPrimary")]Message message, string lockToken, MessageReceiver messageReceiver, ILogger log)
    {
        //Your function logic
        await messageReceiver.DeferAsync(lockToken);
    }
