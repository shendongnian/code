    public class Queue
    {
        public Queue(string connectionString, string queueName)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var proxy = new WebProxy()
            {
                // More properties here
                Address = new Uri("your proxy"),
            };
            DelegatingHandlerImpl delegatingHandlerImpl = new DelegatingHandlerImpl(proxy);
            CloudQueueClient cloudQueueClient = new CloudQueueClient(storageAccount.QueueStorageUri, storageAccount.Credentials, delegatingHandlerImpl);
            CloudQueue = cloudQueueClient.GetQueueReference(queueName);
        }
        private CloudQueue CloudQueue { get; }
        public async Task<string> PeekAsync()
        {
            var m = await CloudQueue.PeekMessageAsync();
            return m.AsString;
        }
    }
