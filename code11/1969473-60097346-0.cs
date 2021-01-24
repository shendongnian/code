    class Program
    {
    	static object _workLockObject = new object();
    	static volatile int _currentPriority = int.MaxValue;
    	static int _interval = 300; // Change it according to your needs
    
    	static void Main()
    	{
    		Task t1 = new Task(() => TryDoWork(1));
    		Task t2 = new Task(() => TryDoWork(2));
    		Task t3 = new Task(() => TryDoWork(3));
    
    		t1.Start();
    		Thread.Sleep(100);
    		t2.Start();
    		Thread.Sleep(100);
    		t3.Start();
    		Console.ReadKey();
    	}
    	public static void TryDoWork(params int[] initialConditions)
    	{
    		var priotity = Interlocked.Increment(ref _currentPriority);
    		while (!Monitor.TryEnter(_workLockObject))// starting to wait when DoWork is available
    		{
    			if (priotity != _currentPriority) // if the thread has stale parameters
    			{
    				Console.WriteLine("DoWork skipped " + initialConditions[0]);
    				return;// skipping Dowork
    			}
    			Thread.Sleep(_interval);
    		}
    		try // beginning of critical section
    		{
    			if (priotity == _currentPriority) // if the thread has the newest parameters
    				DoWork(initialConditions);
    		}
    		finally
    		{
    			Monitor.Exit(_workLockObject); // end of critical section
    		}
    	}
    	public static void DoWork(params int[] initialConditions)
    	{
    		Console.WriteLine("DoWork started " + initialConditions[0]);
    		Thread.Sleep(5000);
    		Console.WriteLine("DoWork ended " + initialConditions[0]);
    	}
    }
