    async Task ContinueAfterT1(Task t1)
    {
    	try
    	{
    		await t1;
    	}
    	catch (Exception)
    	{
    		await Task.Run(() => Console.WriteLine("T fault started"));
    	}
    }
    
    async Task ContinueAfterT2(Task t2)
    {
    	await t2;
    	await Task.Run(() => Console.WriteLine("T3 started"));
    }
