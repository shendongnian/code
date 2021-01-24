	void Main()
	{
		Stopwatch sw = new Stopwatch();
		var ts1 = TimeSpan.Zero;
		var ts2 = TimeSpan.Zero;
	
		Arx rng = new Arx();
	
		for (var x = 0; x < 1000; x++)
		{
			long a = 0;
			sw.Start();
			for (int i = 0; i < 100000; i++)
			{
				a += rng.GenVariable(123);
			}
			sw.Stop();
			ts1 += sw.Elapsed;
			sw.Reset();
			
			a = 0;
			sw.Start();
			for (int i = 0; i < 100000; i++)
			{
				a += rng.GenConstant(123);
			}
			sw.Stop();
			ts2 += sw.Elapsed;
			sw.Reset();		
		}
		
		ts1.TotalMilliseconds.Dump();
		ts2.TotalMilliseconds.Dump();
	}
