    class TestAsyncClass
    {
    	public async Task Run()
    	{
    		var tasks = new List<Task>();
    		Console.WriteLine("starting tasks");
    		var task1 = Task.Run(() => {
    			FakeServerCall1().ContinueWith(async (result) =>
    				{
    					if (!result.IsFaulted && !result.IsCanceled)
    						await FakeLocalCall1();
    				});
    		});
    		tasks.Add(task1);
    
    		var task2 = Task.Run(() => {
    			FakeServerCall2().ContinueWith(async (result) =>
    			{
    				if (result.IsCompletedSuccessfully)
    					await FakeLocalCall2();
    			});
    		}); 
    
    		tasks.Add(task2);
    
    		Console.WriteLine("starting tasks completed");
    
    		await Task.WhenAll(tasks);
    
    		Console.WriteLine("tasks completed");
    	}
    
    	public async Task<bool> FakeServerCall1()
    	{
    		Console.WriteLine("Server1 started");
    		await Task.Delay(3000);
    		Console.WriteLine("Server1 completed");
    		return true;
    	}
    
    	public async Task<bool> FakeServerCall2()
    	{
    		Console.WriteLine("Server2 started");
    		await Task.Delay(2000);
    		Console.WriteLine("Server2 completed");
    		return true;
    	}
    
    	public async Task<bool> FakeLocalCall1()
    	{
    		Console.WriteLine("Local1 started");
    		await Task.Delay(1500);
    		Console.WriteLine("Local1 completed");
    		return true;
    	}
    
    	public async Task<bool> FakeLocalCall2()
    	{
    		Console.WriteLine("Local2 started");
    		await Task.Delay(2000);
    		Console.WriteLine("Local2 completed");
    		return true;
    	}
    }
