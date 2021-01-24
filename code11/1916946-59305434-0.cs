    internal class SinglePool : IRedisCacheConnectionPoolManager
        {
            private readonly IConnectionMultiplexer connection;
    
            public SinglePool(string connectionString)
            {
                this.connection = ConnectionMultiplexer.Connect(connectionString);
            }
    
            public IConnectionMultiplexer GetConnection()
            {
                return connection;
            }
        }
