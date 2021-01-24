        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            lock (lockObj)
            {
                foreach (var eventData in messages)
                {
                    var data = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);
                    Console.WriteLine($"Message received. Partition: '{context.PartitionId}', Data: '{data}'");
                    DoSomethingWithMessage(); // typically takes 15-20 mins to finish this method.
                }
                return context.CheckpointAsync();
            }
        }
