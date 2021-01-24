    var receiver = eventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, PartitionReceiver.EndOfStream);
    
    // Receive a maximum of 100 messages in this call to ReceiveAsync
    var ehEvents = await receiver.ReceiveAsync(100);
    // ReceiveAsync can return null if there are no messages
    if (ehEvents != null)
    {
        // Since ReceiveAsync can return more than a single event you will need a loop to process
        foreach (var ehEvent in ehEvents)
        {
            // Decode the byte array segment
            var message = UnicodeEncoding.UTF8.GetString(ehEvent.Body.Array);
            // Load the custom property that we set in the send example
            var customType = ehEvent.Properties["Type"];
            // Implement processing logic here
        }
    }		
