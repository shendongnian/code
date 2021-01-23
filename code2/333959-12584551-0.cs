    public void StartTimer()
	{
		_timer.Interval = _pollingIntervalMilliseconds;
		_timer.Enabled = true;
		_timer.AutoReset = false; // We must manually restart the timer when we have finished processing
		_timer.Elapsed += CheckForUpdates;
		_timer.Start();
		if (Environment.UserInteractive)
		{
			Console.WriteLine("System now running, press a key to Stop");
			Console.ReadKey();
		}
	}
    private void CheckForUpdates(object sender, ElapsedEventArgs e)
	{
		Console.WriteLine("Checking For Update");
		DoSomethingSlow();
		_timer.Start(); // restarts the timer to hit this method again after the next interval
	}
