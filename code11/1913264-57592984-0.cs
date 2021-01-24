        [FunctionName("processData")]
        public static void Run(
            [ServiceBusTrigger("customer", "customer", AccessRights.Manage, Connection = "ServiceBusConnectionString")]string mySbMsg, string lockToken, MessageReceiver messageReceiver,
            ILogger log)
        {
             log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
            // ...
            await messageReceiver.DeadLetterAsync(lockToken);
            
            // await messageReceiver.AbandonAsync(lockToken);
            // await messageReceiver.CompleteAsync(lockToken);
            // await messageReceiver.DeferAsync(lockToken);
            // ...
        }
