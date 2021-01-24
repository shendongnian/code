	public void ExecuteAndMeasureExecutionTime(System.Action methodToExecute, string logName = null)
	{
		Stopwatch timer = new Stopwatch();
		timer1.Start();
		methodToExecute();
		timer1.Stop();
		Console.WriteLine("Time elapsed from {0}: {1:hh\\:mm\\:ss}", logName ?? "event", stopwatch.Elapsed);
	}
