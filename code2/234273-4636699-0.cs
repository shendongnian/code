    using System;
    using System.Threading;
    using System.Diagnostics;
    
    static class Program
    {
    	static void Main()
    	{
    		const int Hz = 666;
    		var t0 = DateTime.Now;
    		int nCycles = 0;
    		var sw = Stopwatch.StartNew();
    		while (sw.ElapsedMilliseconds < 10000)
    		{
    			++nCycles;
    			var time = t0 + TimeSpan.FromMilliseconds(nCycles * 1000 / Hz);
    			var ttw = (int)((time - DateTime.Now).TotalMilliseconds);
    			if (ttw >= 1)
    				Thread.Sleep(ttw);
    		}
    		Console.WriteLine(nCycles);
    	}
    }
