    public override Task StartAsync(CancellationToken cancellationToken)
        {
            _serviceBusClient.RegisterOnMessageHandlerAndReceiveMessages(MessageReceivedAsync);
            _logger.LogDebug($"Started successfully the Import Client. Listening for messages...");
            return base.StartAsync(cancellationToken);
        }
            public void RegisterOnMessageHandlerAndReceiveMessages(Func<Message, CancellationToken, Task> ProcessMessagesAsync)
        {
            // Configure the message handler options in terms of exception handling, number of concurrent messages to deliver, etc.
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                // Maximum number of concurrent calls to the callback ProcessMessagesAsync(), set to 1 for simplicity.
                // Set it according to how many messages the application wants to process in parallel.
                MaxConcurrentCalls = 1,
                // Indicates whether MessagePump should automatically complete the messages after returning from User Callback.
                // False below indicates the Complete will be handled by the User Callback as in `ProcessMessagesAsync` below.
                AutoComplete = false
            };
            // Register the function that processes messages.
            SubscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }
