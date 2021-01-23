		System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
		sw.Start();
		System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
		sw.Stop();
		// don't load a TimeSpan with ElapsedTicks, these have diff frequency,
		// call Elapsed instead to get TimeSpan.
		TimeSpan t1 = sw.Elapsed;
		Debug.Print("Millisecs: " + t1.TotalMilliseconds);
		// TimeSpan.Elapsed Code
		//if (!SafeNativeMethods.QueryPerformanceFrequency(out Stopwatch.Frequency))
		//{
		//	Stopwatch.IsHighResolution = false;
		//	Stopwatch.Frequency = 10000000L;
		//	Stopwatch.tickFrequency = 1.0;
		//}
		//else
		//{
		//	Stopwatch.IsHighResolution = true;
		//	Stopwatch.tickFrequency = 10000000.0;
		//	Stopwatch.tickFrequency /= (double)Stopwatch.Frequency;
		//}
		//public TimeSpan Elapsed
		//{
		//	[__DynamicallyInvokable]
		//	get
		//	{
		//		return new TimeSpan(this.GetElapsedDateTimeTicks());
		//	}
		//}
		//private long GetElapsedDateTimeTicks()
		//{
		//	long rawElapsedTicks = this.GetRawElapsedTicks();
		//	if (Stopwatch.IsHighResolution)
		//		return (long)((double)rawElapsedTicks * Stopwatch.tickFrequency);
		//	return rawElapsedTicks;
		//}
		TimeSpan t2;
		if (Stopwatch.IsHighResolution)
		{
			t2 = TimeSpan.FromTicks((long)((double)sw.ElapsedTicks * ((double)10000000.0 / (double)Stopwatch.Frequency)));
		}
		else
		{
			t2 = TimeSpan.FromTicks(sw.ElapsedTicks);
		}
		Debug.Assert(t1.TotalMilliseconds == t2.TotalMilliseconds); // true, 
		return;
