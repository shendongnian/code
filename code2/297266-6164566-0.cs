    void Main()
    {
    	Task otherThread = Task.Factory.StartNew(() => UpdateDb(43));
    	Thread.Sleep(100);
    	Console.WriteLine(lazyInt.Value);
    }
    
    static object l = new object();
    Lazy<int> lazyInt = new Lazy<int>(Init, LazyThreadSafetyMode.ExecutionAndPublication);
    
    static int Init()
    {
    	lock(l)
    	{
    		return ReadFromDb();
    	}
    }
    
    void UpdateDb(int newValue)
    {
    	lock(l)
    	{
    		// to make sure deadlock occurs every time
    		Thread.Sleep(1000);
    		
    		if (newValue != lazyInt.Value)
    		{
    			// some code that requires the lock
    		}
    	}
    }
