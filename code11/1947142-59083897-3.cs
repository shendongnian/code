        private static async Task SendMessagesToEventHub(int numMessagesToSend)
        {
            for (var i = 0; i < numMessagesToSend; i++)
            {
                try
                {
                    var message = "444 Message";
                    Console.WriteLine($"Sending message: {message}");
                    EventData mydata = new EventData(Encoding.UTF8.GetBytes(message));
    
                    //here, we add a property named "cg", it's value is the consumer group. By setting this property, then we can read this message via this specified consumer group.
                    mydata.Properties.Add("cg", "newcg");
                    
                    await eventHubClient.SendAsync(mydata);
                    
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                }
    
                await Task.Delay(10);
            }
    
            Console.WriteLine($"{numMessagesToSend} messages sent.");
        }
