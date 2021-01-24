                var messageReceiver = new MessageReceiver(serviceBusConnectionString, "myqueue", ReceiveMode.PeekLock, null, 500);
    
                var tempMessages = await messageReceiver.ReceiveAsync(500, TimeSpan.FromSeconds(1));
                
                foreach (Message m1 in tempMessages)
                {
                    
                    log.LogInformation($"C# HTTP trigger function processed message: {Encoding.UTF8.GetString(m1.Body)}");
                    await messageReceiver.CompleteAsync(m1.SystemProperties.LockToken);
    
                }
