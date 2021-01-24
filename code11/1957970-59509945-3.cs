    [Fact]
    public async Task IfReceivesAndPublishesEvents()
    {
        // Arrange
        _rabbitMQBus.Subscribe<
              ProcessCompletedIntegrationEvent,
              ProcessCompletedIntegrationEventHandler>();
        // You would need to register dependecies if you use DI here
        // or in some central TestFixture class or similar
        // you would do something like
        // Act
        EventbusIntegrationTest.Publish(new ProcessIntegrationEvent(name: "test"));
        // Assert 
        //Assert state has changed ....
    }
    public static class EventbusIntegrationTest
    {
        private static int minimumLatency = 20;
        public static void Publish(Event @event)
        {
            Eventbus.Publish(@event);
            // after each published event you will wait at least the minimum latency time 
            // before doing any other action
            Task.Delay(minimumLatency).Wait();
        }
    }
