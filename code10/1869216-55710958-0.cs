    `private readonly Lazy<Task<QueueClient>> asyncClient;
     private readonly QueueClient client;`
      
        public MessageBusService(string connectionString, string queueName)
        {
            asyncClient = new Lazy<Task<QueueClient>>(async () =>
            {
                var managementClient = new ManagementClient(connectionString);
                var allQueues = await managementClient.GetQueuesAsync();
                var foundQueue = allQueues.Where(q => q.Path == queueName.ToLower()).SingleOrDefault();
                if (foundQueue == null)
                {
                    await managementClient.CreateQueueAsync(queueName);//add queue desciption properties
                }
                return new QueueClient(connectionString, queueName);
            });
            client = asyncClient.Value.Result; 
        }
