c#
static void Main(string[] args)
{
	// Counter variables
	var counterLock = new object();
	int received = 0;
	int sent = 0;
	// Fetch ID of all Firefox processes
	var processList = Process.GetProcessesByName("firefox").Select(p => p.Id).ToHashSet();
	// Run in another thread, since this will be a blocking operation (see below)
	Task.Run(() =>
	{
		// Start ETW session
		using(var session = new TraceEventSession("MyKernelAndClrEventsSession"))
		{
			// Query network events
			session.EnableKernelProvider(KernelTraceEventParser.Keywords.NetworkTCPIP);
			// Subscribe to trace events
			// These will be called by another thread, so locking is needed here
			session.Source.Kernel.TcpIpRecv += data =>
			{
				if(processList.Contains(data.ProcessID))
					lock(counterLock)
						received += data.size;
			};
			session.Source.Kernel.TcpIpSend += data =>
			{
				if(processList.Contains(data.ProcessID))
					lock(counterLock)
						sent += data.size;
			};
			// Process all events (this will block)
			session.Source.Process();
		}
	});
	// Program logic to handle counter values
	while(true)
	{
		// Wait some time and print current counter status
		Task.Delay(2000).Wait();
		lock(counterLock)
			Console.WriteLine($"Sent: {sent.ToString("N0")} bytes    Received: {received.ToString("N0")} bytes");
	}
}
Note that you need elevated (administrator) privileges to execute this code.
I tested with Mozilla Firefox, which had 10 processes (7 tabs) running at that time; I downloaded a big file, and the program correctly printed the added network traffic (plus some noise from active tabs), without including the involved disk accesses (which would have at least doubled the measured traffic).
