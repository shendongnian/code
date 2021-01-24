    public static class Function7
    {
        [FunctionName("Function7")]
        [return: ServiceBus("test2", Connection = "AzureServiceBusConnectionString", EntityType = EntityType.Queue)] 
        public static async Task<Message> Run([ServiceBusTrigger("test", Connection = "AzureServiceBusConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var message = new Message(Encoding.UTF8.GetBytes("{}"));
            message.Label = "Hello";
            message.UserProperties.Add("abc", 123);
            return await Task.FromResult<Message>(message);
        }
    }
