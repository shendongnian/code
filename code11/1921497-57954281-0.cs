    [FunctionName("Function1")]
        public static async System.Threading.Tasks.Task RunAsync([ServiceBusTrigger("myqueue", Connection = "ConnectionString")]
            MessageReceiver messageReceiver,
            ILogger log, 
            [ServiceBus("test", Connection = "ConnectionString")]MessageSender messagesQueue)
        {
            Console.Write(messageReceiver.Path);
            Message m1 = await messageReceiver.PeekAsync();
            await messagesQueue.SendAsync(m1);
        }
