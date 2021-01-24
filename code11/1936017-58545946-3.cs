static void Main()
{
	using (var cts = new CancellationTokenSource())
	{
        // Start the worker thread and pass the
        // CancellationToken to it
		Console.WriteLine("MAIN: Starting worker thread");
        var worker = Task.Run(() => dssPut_Command(cts.Token));
        // Make the token cancel automatically after 3 seconds
		cts.CancelAfter(3000);
		// Wait for worker thread to exit
		Console.WriteLine("MAIN: Waiting for the worker to exit");
		worker.Wait();
		Console.WriteLine("MAIN: Main thread exiting after worker exited");
	}
}
static void dssPut_Command(object tokenObj)
{
	Console.WriteLine("WORKER: Worker thread started");
	var cancellationToken = (CancellationToken)tokenObj;
    // You can check if cancellation has been requested
	if (cancellationToken.IsCancellationRequested)
    {
        // If there's no need to clean up, you can just return
		return;
    }
	try
	{
        // Or you can throw an OperationCanceledException automatically
        cancellationToken.ThrowIfCancellationRequested();
		// Pass the CancellationToken to any methods you call
		// so they can throw OperationCanceledException when
		// the token is canceled.
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
