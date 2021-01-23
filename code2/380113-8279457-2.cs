	static void Main()
	{
		LimitedConcurrencyLevelTaskScheduler ts = new LimitedConcurrencyLevelTaskScheduler( 1 );
		int[] range = { 1, 2, 3 };
		var tasks = range.Select( number =>
			{
				var task = QueueReadTask( ts, number );
				return task.ContinueWith( t => Output.Write( "Number " + number + " completed" ) );
			}
		)
		.ToArray();
		Output.Write( "Waiting for " + tasks.Length + " tasks: " + String.Join( " ", tasks.Select( t => t.Status ).ToArray() ) );
		Task.WaitAll( tasks );
		Output.Write( "WaitAll complete for " + tasks.Length + " tasks: " + String.Join( " ", tasks.Select( t => t.Status ).ToArray() ) );
	}
