static void Main()
{
	using (var cts = new CancellationTokenSource())
	{
        // Start the worker thread and pass the
        // CancellationToken to it
		var thread = new Thread(WorkerThread);
		Console.WriteLine("MAIN: Starting worker thread");
		thread.Start(cts.Token);
        Console.WriteLine("MAIN: Waiting 3 seconds");
		Thread.Sleep(3000);
		Console.WriteLine("MAIN: Signaling cancellation");
		cts.Cancel();
		// Wait for worker thread to exit
		thread.Join();
		Console.WriteLine("MAIN: Main thread exiting after worker exited");
	}
}
static void WorkerThread(object tokenObj)
{
	Console.WriteLine("WORKER: Worker thread started");
	var cancellationToken = (CancellationToken)tokenObj;
	if (cancellationToken.IsCancellationRequested)
		return;
	try
	{
		// Pass the CancellationToken down, and either check
		// token.IsCancellationRequested or call
		// token.ThrowIfCancellationRequested() at opportune times.
		DoWork(cancellationToken);
	}
	catch (OperationCanceledException)
	{
        // Do any clean-up work, if necessary
		Console.WriteLine("WORKER: Worker exiting gracefully");
	}
}
static void DoWork(CancellationToken cancellationToken)
{
	// Simulating a long running operation
	Task.Delay(TimeSpan.FromMinutes(1), cancellationToken).GetAwaiter().GetResult();
}
