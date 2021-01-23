    using System;
    using System.Timers;
    using System.Diagnostics;
    
    public static class Test
    {
    	public static void Main(String[] args)
    	{
    		Timer timer = new Timer();
    		timer.Interval = 1;
    		timer.Enabled = true;
    		
    		Stopwatch sw = Stopwatch.StartNew();
    		long start = 0;
    		long end = sw.ElapsedMilliseconds;
    
    		timer.Elapsed += (o, e) =>
    		{
    			start = end;
    			end = sw.ElapsedMilliseconds;
    			Console.WriteLine("{0} milliseconds passed", end - start);
    		};
    		
    		Console.ReadLine();
    	}
    }
