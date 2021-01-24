            public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
            {
                foreach (var eventData in messages)
                {
                    //filter the data here
                    if (eventData.Properties["cg"].ToString() == "$Default")
                    {                    
                        var data = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);
                        
                        Console.WriteLine($"Message received. Partition: '{context.PartitionId}', Data: '{data}'");
                        Console.WriteLine(context.ConsumerGroupName);
                    }
                }
    
                return context.CheckpointAsync();
            }
