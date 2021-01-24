using MeshIntegrationBus.RabbitMQ;
public class Startup
{
   public RabbitMqConfig GetRabbitMqConfig()
   {
      ExchangeType exchangeType = (ExchangeType)Enum.Parse(typeof(ExchangeType),
         Configuration["RabbitMQ:IntegrationEventExchangeType"], true);
      var rabbitMqConfig = new RabbitMqConfig
      {
         ExchangeName = Configuration["RabbitMQ:IntegrationEventExchangeName"],
         ExchangeType = exchangeType,
         HostName = Configuration["RabbitMQ:HostName"],
         VirtualHost = Configuration["RabbitMQ:VirtualHost"],
         UserName = Configuration["RabbitMQ:UserName"],
         Password = Configuration["RabbitMQ:Password"],
         ClientProviderName = Configuration["RabbitMQ:ClientProviderName"],
         Port = Convert.ToInt32(Configuration["RabbitMQ:Port"])
       }
      return rabbitMqConfig
   }
   public void ConfigureServices(IServicecollection services)
   {
      services.Add.... // All your stuff
      // If this service will also publish events, add that Service as well (scoped!)
      services.AddScoped<IMeshEventPublisher, RabbitMqEventPublisher>(s =>
         new RabbitMqEventPublisher(rabbitConfig));
      // Since this service will be a singleton, wait until the end to actually add it
      // to the servicecollection - otherwise BuildServiceProvider would duplicate it
      RabbitMqListener rabbitMqListener = new RabbitMqListener(rabbitConfig, 
         services.BuildServiceProvider());
      var nodeEventSubs = Configuration.GetSection(
         $"RabbitMQ:SubscribedEventIds:ServiceA").Get<string[]>();
      // Attach our list of events to a handler
      // Handler must implement IMeshEventProcessor and does have
      // access to the IServiceProvider so can use DI
      rabbitMqListener.Subscribe<ServiceAEventProcessor>(nodeEventSubs);
      services.AddSingleton(rabbitMqListener);
   }
}
That's really all there is to it.  You can add multiple handlers per subscribed event and/or reuse the same handler(s) for multiple events.  It's proven pretty flexible and reliable - we've been using it for a couple years - and it's easy enough to change/update as needed and let individual services pull the changes when they want/need to.
