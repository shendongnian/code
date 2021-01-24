    public async Task Run()
    {
    	var tasks = new List<Task>();
    	Console.WriteLine("starting tasks");
    	var task1 = Task.Run(async () =>
    	{
    		await FakeServerCall1();
    		await FakeLocalCall1();
    	});
    	tasks.Add(task1);
    
    	var task2 = Task.Run(async() =>
    	{
    		await FakeServerCall2();
    		await FakeLocalCall2();
    	}); 
    
    	tasks.Add(task2);
    
    	Console.WriteLine("starting tasks completed");
    
    	await Task.WhenAll(tasks);
    
    	Console.WriteLine("tasks completed");
    }
