    private AutoResetEvent mWorkerHandle = new AutoResetEvent(initialState: false);
    private AutoResetEvent mTimerHandle = new AutoResetEvent(initialState: false);
    
    // ... Inside method that initializes the threads
    {
    	Thread workerThread = new Thread(new ThreadStart(Worker_DoWork));
    	Thread timerThread = new Thread(new ThreadStart(Timer_DoWork));
    	
    	workerThread.Start();
    	timerThread.Start();
    	
    	// Signal the timer to execute
    	mTimerHandle.Set();
    }
    
    // ... Example thread methods
    private void Worker_DoWork()
    {
    	while (true)
    	{
    		// Wait until we are signalled
    		mWorkerHandle.WaitOne();
    	
    		// ... Perform execution ...	
    		
    		// Signal the timer
    		mTimerHandle.Set();
    	}
    }
    
    private void Timer_DoWork()
    {
    	// Signal the worker to do something
    	mWorkerHandle.Set();
    	
    	// Wait until we get signalled
    	mTimerHandle.WaitOne();
    	
    	// ... Work has finished, do something ...
    }
