    async Task Main()
    {
    	var batchSize = 10;
    	var batches = logins.Select((item, inx) => new { item, inx })
    					.GroupBy(x => x.inx / batchSize)
    					.Select(g => g.Select(x => x.item));
    					
    	foreach (var batch in batches)
    	{
    		var tasks = new List<Task>(batchSize);
    		foreach (var login  in batch)
    		{
    			tasks.Add(DoWork());
    		}
    		await Task.WhenAll(tasks);
    	}
    }
    
    public async Task DoWork()
    {
    	if (await _serviceLoginInjected.LogIn(login))
    	{
    		await _serviceLoginInjected.SendEmails();
    		await _serviceLoginInjected.CreateFiles();
    		await _serviceLoginInjected.DoSomethingElse();
    	}
    }
