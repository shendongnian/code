    public static class AdvancedBusExtensions
    {
        public static async Task ResendErrorsAsync(this IAdvancedBus source, string errorQueueName)
        {
            var errorQueue = await source.QueueDeclareAsync(errorQueueName);
            var message = await source.GetMessageAsync(errorQueue);
            while (message != null)
            {
                var utf8Body = Encoding.UTF8.GetString(message.Body);
                var error = JsonConvert.DeserializeObject<Error>(utf8Body);
                var errorBodyBytes = Encoding.UTF8.GetBytes(error.Message);
                var exchange = await source.ExchangeDeclareAsync(error.Exchange, x =>
                {
                    // This can be adjusted to fit the exchange actual configuration 
                    x.AsDurable(true);
                    x.AsAutoDelete(false);
                    x.WithType("topic");
                });
                await source.PublishAsync(exchange, error.RoutingKey, true, error.BasicProperties, errorBodyBytes);
                message = await source.GetMessageAsync(errorQueue);
            }
        }
    }
