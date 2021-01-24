    private static void RegisterOnMessageHandlerAndReceiveMessages()
    {
        IQueueClient queueClient = new QueueClient(serviceBusConnectionString, serviceBusQueueName);
        ///....
    }
