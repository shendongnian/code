 IQueueClient queueClient = new QueueClient(
     namespaceConnectionString,
     queueName,
     ReceiveMode.PeekLock,
     RetryExponential);
**Send a message to the queue:**
 byte[] data = GetData();
 await queueClient.SendAsync(data);
**Register a message handler which will be invoked every time a message is received.**
 queueClient.RegisterMessageHandler(
        async (message, token) =>
        {
            // Process the message
            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
            // Complete the message so that it is not received again.
            // This can be done only if the queueClient is opened in ReceiveMode.PeekLock mode.
            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        },
        async (exceptionEvent) =>
        {
            // Process the exception
            Console.WriteLine("Exception = " + exceptionEvent.Exception);
            return Task.CompletedTask;
        });
**UPDATE - Mocking the client**
There's no reason to inherit from either class, unless one wants to *mock* them. In this case the Microsoft.Azure.ServiceBus.QueueClient class makes mocking easy as it inherits from the [IQueueClient](https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.servicebus.iqueueclient?view=azure-dotnet) interface. One can create a mock client by implementing this interface or using a mocking library like Moq to mock only the relevant methods
