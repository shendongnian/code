                public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
                {
                    foreach (var eventData in messages)
                    {
                        //filter the data here, using another consumer group name
                        if (eventData.Properties["cg"].ToString() == "newcg")
                        {  
                           //other code
                        }
                       }
                     return context.CheckpointAsync();
                   }
