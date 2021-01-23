    Task t = Task.Factory.StartNew(
    	() =>
    	{
    		Thread.Sleep(1000);
    	});
    if (t.Wait(500))
    {
    	Console.WriteLine("Success.");
    }
    else
    {
    	Console.WriteLine("Timeout.");
    }
