    async Task Main()
    {	
    	for(int x = 0; x < 5;x++)
    	{
    		await Test(x);
    		s.WaitOne();
    	}	
    }
    
    Semaphore s = new Semaphore(0,2);
    
    async Task Test(int x)
    {
    	$"Entering : {x}".Dump();
    	await Task.Delay(3000);
    	s.Release();
    }
