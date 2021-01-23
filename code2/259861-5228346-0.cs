    void Application_Start(...)
    {
    	Thread thread = new Thread(CronThread);
    	thread.IsBackground = true;
    	thread.Start();
    }
       
    private void CronThread()
    {
    	while(true)
    	{
    		Thread.Sleep( TimeSpan.FromMinutes( 30 ) );
    		// Do something every half hour
    	}
    }
