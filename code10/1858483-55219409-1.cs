           ConnectionFactory factory = new ConnectionFactory();// assign factory details
           IConnection _connection = factory.CreateConnection();
           IModel  _model = _connection.CreateModel();
           _model.ExchangeDeclare("RmqExchangeName", "topic", true);
           _model.QueueBind(queue: queueName,exchange: "RmqExchangeName",routingKey: "");
           var consumer = new EventingBasicConsumer(_model);
            consumer.Received += (object ch, BasicDeliverEventArgs ea) =>
            {
                   var message = Encoding.Default.GetString(ea.Body);
                    MemoryStream payloadstream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new UriDto { Url = message })));
                    Helper.Log("Start  Message");
                    // Do something with payloadstream
                    Helper.Log("Sent  Message");
                    _model.BasicAck(ea.DeliveryTag, false);
             };
           _model.BasicConsume(RmqQueueName, true, consumer);
