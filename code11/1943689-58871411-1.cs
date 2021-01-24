            private static async Task MainAsync(string[] args)
            {
                Console.WriteLine("Registering EventProcessor...");
    
                var eventProcessorHost = new EventProcessorHost(
                    EventHubName,
                    PartitionReceiver.DefaultConsumerGroupName,
                    EventHubConnectionString,
                    StorageConnectionString,
                    StorageContainerName);
    
                //here, you can get only the data sent in event hub in the recent an hour.
                var options = new EventProcessorOptions
                {
                                        
                    InitialOffsetProvider = (partitionId) => EventPosition.FromEnqueuedTime(DateTime.UtcNow.AddHours(-1))
                };
    
    
                // Registers the Event Processor Host and starts receiving messages                
    
                await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>(options);
    
                Console.WriteLine("Receiving. Press ENTER to stop worker.");
                Console.ReadLine();
    
                // Disposes of the Event Processor Host
                await eventProcessorHost.UnregisterEventProcessorAsync();
            }
