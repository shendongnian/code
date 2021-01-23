	private CancellationTokenSource taskToken;
	private AutoResetEvent awaitReplyOnRequestEvent = new AutoResetEvent(false);
	void Main()
	{
		// Start a task which is doing nothing but sleeps 1s
		LaunchTaskAsync();
		Thread.Sleep(100);
		// Stop the task
		StopTask();
	}
	/// <summary>
	///		Launch task in a new thread
	/// </summary>
	void LaunchTaskAsync()
	{
		taskToken = new CancellationTokenSource();
		Task.Factory.StartNew(() =>
			{
				try
				{	//Capture the thread
					runningTaskThread = Thread.CurrentThread;
					// Run the task
					if (taskToken.IsCancellationRequested || !awaitReplyOnRequestEvent.WaitOne(10000))
						return;
					Console.WriteLine("Task finished!");
				}
				catch (Exception exc)
				{
					// Handle exception
				}
			}, taskToken.Token);
	}
	/// <summary>
	///		Stop running task
	/// </summary>
	void StopTask()
	{
		// Attempt to cancel the task politely
		if (taskToken != null)
		{
			if (taskToken.IsCancellationRequested)
				return;
			else
				taskToken.Cancel();
		}
		// Notify a waiting thread that an event has occurred
		if (awaitReplyOnRequestEvent != null)
			awaitReplyOnRequestEvent.Set();
		// If 1 sec later the task is still running, kill it cruelly
		if (runningTaskThread != null)
		{
			try
			{
				runningTaskThread.Join(TimeSpan.FromSeconds(1));
			}
			catch (Exception ex)
			{
				runningTaskThread.Abort();
			}
		}
	}
