    void SetupMemoryCheck()
    {
    	Action<CancellationToken> BeCheckingTheMemory = null;
    	BeCheckingTheMemory = ct =>
    	{
    		Thread.Sleep(500);
    		CheckMemory_OptionallyReleaseOldHandles();
    
    		if (ct.IsCancellationRequested)
    		{
    				return;
    		}
    
    		BeCheckingTheMemory(ct);
    	};
    
    	HostingEnvironment.QueueBackgroundWorkItem(ct =>
    	{
    		var tf = new TaskFactory(ct, TaskCreationOptions.LongRunning, TaskContinuationOptions.None, TaskScheduler.Current);
    		tf.StartNew(() => BeCheckingTheMemory(ct));
    	});
    }
