    [FunctionName("Function8")]
        public static async Task Run([ServiceBusTrigger("topic2", "test2", Connection = "AzureServiceBusConnectionString")]string mySbMsg, string lockToken, MessageReceiver messageReceiver, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
            try
            {
                throw new Exception();
                // await messageReceiver.CompleteAsync(lockToken);
            }
            catch (Exception ex)
            {
                await messageReceiver.DeadLetterAsync(lockToken);
            }
        }
