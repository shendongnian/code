    protected override async Task ExecuteAsync(CancellationToken stoppingQueueToken)
    {
    	var work = await TaskQueue.DequeueAsync(stoppingQueueToken);
    	List<Task> taskList = new List<Task>();
    	while (!stoppingQueueToken.IsCancellationRequested)
    	{
    		await redirect(work, stoppingQueueToken);
    	}
    }
    
    public async Task redirect(Func<CancellationToken, Task> work, CancellationToken stoppingQueueToken)
    {
    	await work(stoppingQueueToken);
    }
