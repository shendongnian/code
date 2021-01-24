    class Program
        {
            //I declare as class fields so they are not garbage collected and the consumer can stay alive
            private EventingBasicConsumer _consumer;
            private IModel _channel;
            private IConnection _connection;
    
            public bool Stop()
            {
                _channel.Dispose();
                _connection.Dispose();
                return true;
            }
    
            public bool Start()
            {
    
                var factory = new ConnectionFactory() {HostName = "localhost"};
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
    
                _channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
    
                _consumer = new EventingBasicConsumer(_channel);
                _consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
    
                };
                _channel.BasicConsume(queue: "hello",
                    autoAck: true,
                    consumer: _consumer);
    
                return true;
            }
    
    
            public static void Main()
            {
    
                var rc = HostFactory.Run(x => //1
                {
                    x.Service<Program>(s => //2
                    {
                        s.ConstructUsing(name => new Program()); //3
                        s.WhenStarted(tc => tc.Start()); //4
                        s.WhenStopped(tc => tc.Stop()); //5
                    });
                    x.RunAsLocalSystem(); //6
    
                    x.SetDescription("Sample Topshelf Host"); //7
                    x.SetDisplayName("Stuff"); //8
                    x.SetServiceName("Stuff"); //9
                }); //10
    
                var exitCode = (int) Convert.ChangeType(rc, rc.GetTypeCode()); //11
                Environment.ExitCode = exitCode;
            }
        }
