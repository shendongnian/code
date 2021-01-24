    public class SampleEventProcessor : IEventProcessor
    {
        public Task OpenAsync(PartitionContext context)
        {
            Console.WriteLine($"Opened partition {context.PartitionId}");
            return Task.FromResult<object>(null);
        }
        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine($"Closed partition {context.PartitionId}");
            return Task.FromResult<object>(null);
        }
        public async Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (var eventData in messages)
            {
                // Process the mesasage in downstream agent.
                await DownstreamAgent.ProcessEventAsync(eventData);
                // Checkpoint current position.
                await context.CheckpointAsync();
            }
        }
        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            Console.WriteLine($"Partition {context.PartitionId} - {error.Message}");
            return Task.CompletedTask;
        }
    }
    public class DownstreamAgent
    {
        const int DegreeOfParallelism = 1;
        static SemaphoreSlim threadSemaphore = new SemaphoreSlim(DegreeOfParallelism, DegreeOfParallelism);
        public static async Task ProcessEventAsync(EventData message)
        {
            // Wait for a spot so this message can get processed.
            await threadSemaphore.WaitAsync();
            try
            {
                // Process the message here
                var data = Encoding.UTF8.GetString(message.Body.Array);
                Console.WriteLine(data);
            }
            finally
            {
                // Release the semaphore here so that next message waiting can be processed.
                threadSemaphore.Release();
            }
        }
    }
