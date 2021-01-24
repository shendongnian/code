         ConnectionFactory oFactory = new ConnectionFactory();
         oFactory.UserName = oRabbitMQData.userName;
         oFactory.Password = oRabbitMQData.password;
         oFactory.VirtualHost = oRabbitMQData.virtualHost;
         oFactory.HostName = oRabbitMQData.hostName;
         oFactory.Port = oRabbitMQData.port;
         var connection = oFactory.CreateConnection();
         var channel = connection.CreateModel();
         // setup signal
         var signal = new ManualResetEvent(true);
         oRabbitMQConnections.Add(connection);
         oRabbitMQChannels.Add(channel);
         var consumer = new EventingBasicConsumer(channel);
         byte[] messageBody = null;
         consumer.Received += (sender, args) =>
         {
            messageBody = args.Body;
            string sMsg = UTF8Encoding.UTF8.GetString(messageBody);
            // process your message or store for later
            // set signal
            channel.BasicAck(args.DeliveryTag, false);
           // Do something
            signal.Set();
         };
         // start consuming
         channel.BasicConsume(oRabbitMQData.queueName, false, consumer);
