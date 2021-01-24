        static void Main( string[] args )
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", true, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (s, e) =>
                    {
                        var message = Encoding.UTF8.GetString(e.Body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };
                    channel.BasicConsume("hello", true, consumer);
                    Console.WriteLine(" [*] Waiting for messages." +
                                             "To exit press CTRL+C");
                    Console.ReadLine();
                }
            }
        }
