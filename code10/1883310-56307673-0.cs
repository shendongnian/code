    IBusControl busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        IRabbitMqHost host = cfg.Host(new Uri(RabbitMQConstants.RabbitMQUri),
            hst =>
            {
                hst.Username(RabbitMQConstants.RabbitMQUserName);
                hst.Password(RabbitMQConstants.RabbitMQPassword);
            });
        cfg.ReceiveEndpoint(host,
            RabbitMQConstants.YourQueueName,
            endPointConfigurator => { 
                endPointConfigurator.Consumer<SomeConsumer>();
                endPointConfigurator.UseConcurrencyLimit(4);
            });
    });
    busControl.Start();
    public class SomeConsumer :
        IConsumer<YourMessageClass>
    {
        public async Task Consume(ConsumeContext<YourMessageClass> context)
        {
            await Console.Out.WriteLineAsync($"Message consumed: {context.Message.YourValue}");
    
        }
    }
