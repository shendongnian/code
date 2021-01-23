    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    
    class Program
    {
    	readonly List<int> l = new List<int>();
    	const int amount = 1000;
    	int toFinish = amount;
    	readonly AutoResetEvent are = new AutoResetEvent(false);
    
    	static void Main()
    	{
    		new Program().Run();
    	}
    
    	void Run()
    	{
    		for (int i = 0; i < amount; i++)
    			new Thread(AddTol).Start(i);
    
    		are.WaitOne();
    
    		if (l.Count != amount ||
		        l.Distinct().Count() != amount ||
                l.Min() < 0 ||
		        l.Max() >= amount)
			    throw new Exception("omg corrupted data");
    
    		Console.WriteLine("All good");
    		Console.ReadKey();
    	}
    
    	void AddTol(object o)
    	{
            // uncomment to fix
            // lock (l) 
    		l.Add((int)o);
    		int i = Interlocked.Decrement(ref toFinish);
    
    		if (i == 0)
    			are.Set();
    	}
    }
