	private Thread executionThread;
	private object SyncObject {get;set;}
	private delegate void DispatcherMethod();
	private void InitDispatcher()
	{
		this.SyncObject = new object();
		// Set up the dispatcher pump.  See Dispatcher.Run on MSDN.
		this.executionThread = new Thread(StartDispatcher);
		lock (this.SyncObject)
		{
			this.executionThread.Start();
			Monitor.Wait(this.SyncObject);
		}
	}	
	private void StartDispatcher()
	{
		DispatcherMethod method = DispatcherStarted;
		// Enqueue a started event by adding an initial method on the message pump.
		// Use BeginInvoke because the dispatcher is not actually running yet.
		// The call to Dispatcher.CurrentDispatcher handles creating the actual
		// Dispatcher instance for the thread (see MSDN - Dispatcher.FromThread
		// does not initialize the Dispatcher).
		Dispatcher.CurrentDispatcher.BeginInvoke(method);
		Dispatcher.Run();
	}
	private void DispatcherStarted()
	{
		lock (this.SyncObject)
		{
			Monitor.Pulse(this.SyncObject);
		}
	}
