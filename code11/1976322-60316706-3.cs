    public ServiceBusClient(
            string endpoint,
            string topicName,
            string subscriberName,
            string subscriberKey, ReceiveMode mode = ReceiveMode.PeekLock)
        {
            var connBuilder = new ServiceBusConnectionStringBuilder(endpoint, topicName, subscriberName, subscriberKey);
            var connectionString = connBuilder.GetNamespaceConnectionString();
            ConnectionString = connectionString;
            TopicName = topicName;
            SubscriptionName = topicName;
            SubscriptionClient = new SubscriptionClient(connectionString, topicName, subscriberName, mode);
        }
