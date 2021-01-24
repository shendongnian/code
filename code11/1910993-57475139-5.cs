    public async Task<bool> FakeServerCall2()
    {
    	Console.WriteLine("Server2 started");
    	await Task.Delay(1000);
    	Console.WriteLine("Crashing Server2");
    	throw new Exception("Oops server 2 crashed");
    }
    
    public async Task<bool> FakeLocalCall1()
    {
    	Console.WriteLine("Local1 started");
    	await Task.Delay(1500);
    	Console.WriteLine("crashing local1");
    	throw new Exception("Oh ohh, local1 crashed");
    }
