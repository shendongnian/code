    public static async Task ServiceBusBinderTest(
     string message,
     int numMessages,
     Binder binder) {
     var attribute = new ServiceBusAttribute(BinderQueueName) {
      EntityType = EntityType.Queue
     };
     var collector = await binder.BindAsync < IAsyncCollector < string >> (attribute);
     for (int i = 0; i < numMessages; i++) {
      await collector.AddAsync(message + i);
     }
     await collector.FlushAsync();
    }
