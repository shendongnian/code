    Action<IAsyncResult> myAction = (IAsyncResult ar) =>
    {
    	// Send Nigerian Prince emails
    	Console.WriteLine("Starting task");
    	Thread.Sleep(2000);
    
    	// Finished
    	Console.WriteLine("Finished task");
    	
    };
    
    IAsyncResult result = myAction.BeginInvoke(null,null,null);
    while (!result.IsCompleted)
    {
    	// Do something while you wait
    	Console.WriteLine("I'm waiting...");
    }
