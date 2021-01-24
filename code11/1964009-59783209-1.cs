    public class RabbitMQImpl : IQueue
    {
            private Connection _connection;
            private Channel _channel;
    
            private readonly IBotFactory _factory;
            public RabbitMQImpl(IBotFactory factory)
            {     
                _factory = factory;
            }
            public void StartListening()
            {  
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672
                };
                _connection = factory.CreateConnection();
                _channel = connection.CreateModel();
                
                // your code
            }
    }
