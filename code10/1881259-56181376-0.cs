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
                    string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes( message );
                    while ( true )
                    {
                        Console.WriteLine( "Press key to send message" );
                        Console.ReadLine();
                        channel.BasicPublish( "", "hello", null, body );
                        Console.WriteLine( " [x] Sent {0}", message );
                    }
                }
            }
