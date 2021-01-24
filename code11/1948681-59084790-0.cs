    public class MyEventProcessor : IEventProcessor
    {
        private Stopwatch checkpointStopWatch;
 
        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            Console.WriteLine(error.ToString());
            return Task.FromResult(true);
        }
 
        async Task IEventProcessor.CloseAsync(PartitionContext context, CloseReason reason)
        {
            if (reason == CloseReason.Shutdown)
            {
                await context.CheckpointAsync();
            }
        }
 
        Task IEventProcessor.OpenAsync(PartitionContext context)
        {
            var eventHubPartitionId = context.PartitionId;
            Console.WriteLine($"Registered reading from the partition: {eventHubPartitionId} ");
            this.checkpointStopWatch = new Stopwatch();
            this.checkpointStopWatch.Start();
            return Task.FromResult<object>(null);
        }
 
        //Data comes in here
        async Task IEventProcessor.ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (var eventData in messages)
            {
                var data = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);
                Console.WriteLine($"Message Received from partition {context.PartitionId}: {data}");
            }
 
            await context.CheckpointAsync();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string processorHostName = Guid.NewGuid().ToString();
            var Options = new EventProcessorOptions()
            {
                MaxBatchSize = 1,
            };
            Options.SetExceptionHandler((ex) =>
            {
                System.Diagnostics.Debug.WriteLine($"Exception : {ex}");
            });
            var eventHubCS = "event hub connection string";
            var storageCS = "storage connection string";
            var containerName = "test";
            var eventHubname = "test2";
            EventProcessorHost eventProcessorHost = new EventProcessorHost(eventHubname, "$Default", eventHubCS, storageCS, containerName);
            eventProcessorHost.RegisterEventProcessorAsync<MyEventProcessor>(Options).Wait();
 
            while(true)
            {
                //do nothing
            }
        }
    }
