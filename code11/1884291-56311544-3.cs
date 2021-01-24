    public class RabbitMQManager : IDisposable
    {
        private bool _disposed = false;
        private IModel _channel;
        private IConnection _connection;
        public event EventHandler<string> MessageReceived;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _channel?.Dispose();
                    _connection?.Dispose();
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        public void Connect()
        {
            var factory = new ConnectionFactory { HostName = "xxx", UserName = "xxx", Password = "xxx" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "call_notify", type: "fanout");
            string queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName,
                              exchange: "call_notify",
                              routingKey: "");
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body;
                string message = Encoding.UTF8.GetString(body);
                MessageReceived?.Invoke(this, message);
            };
            _channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
