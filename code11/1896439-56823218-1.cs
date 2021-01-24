    var conf = new ConsumerConfig
    {
        // ..
        EnableAutoCommit = false
    };
    
    
    // ..
    
    	try
        {
            var cr = c.Consume(cts.Token);
    		
    		// .. save data to database ..
    		c.Commit(); // <-----
    
            Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
        }
        catch (ConsumeException e)
        {
            Console.WriteLine($"Error occured: {e.Error.Reason}");
        }
