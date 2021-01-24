                string serviceBusConnectionString = Environment.GetEnvironmentVariable("servicebuscon");
                var messageReceiver = new MessageReceiver(serviceBusConnectionString, "myqueue", ReceiveMode.ReceiveAndDelete, null, 500);
    
    
                var tempMessages = await messageReceiver.ReceiveAsync(500, TimeSpan.FromSeconds(1));
