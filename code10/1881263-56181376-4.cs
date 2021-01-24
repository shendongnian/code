        // producer
        static void Main( string[] args )
        {
            var factory = new ConnectionFactory() 
            { 
                HostName = "localhost"                
            };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare( "hello", true, false, false, null );
                    channel.ExchangeDeclare( "helloe", "fanout", true );
                    channel.QueueBind( "hello", "helloe", "" );
                    string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes( message );
                    while ( true )
                    {
                        Console.WriteLine( "Press key to send message" );
                        Console.ReadLine();
                        channel.BasicPublish( "helloe", "", null, body );
                        Console.WriteLine( " [x] Sent {0}", message );
                    }
                }
            }
            Console.WriteLine( "finished" );
            Console.ReadLine();
        }
