	static ManualResetEvent mre = new ManualResetEvent( false );
	static int inFlight = 1; // start with 1 to fix race condition
	static void DoWork()
	{
		for ( int i = 0 ; i < 10 ; i++ )
		{
			var bw = new BackgroundWorker();
			bw.DoWork += bw_DoWork;
			bw.RunWorkerCompleted += bw_RunWorkerCompleted;
			Interlocked.Increment( ref inFlight );
			bw.RunWorkerAsync();
		}
		if ( Interlocked.Decrement( ref inFlight ) == 0 ) mre.Set();
		mre.WaitOne(); // this blocks until all workers have completed
	}
	static void bw_DoWork( object sender, DoWorkEventArgs e )
	{
		Thread.Sleep( 1000 );
	}
	static void bw_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
	{
		if ( Interlocked.Decrement( ref inFlight ) == 0 ) mre.Set();
	}
