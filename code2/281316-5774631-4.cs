	// The event that should be raised when a progress occurs.
	private event ProgressChangedEventHandler UpdateProgressChanged;
	// The task the ProgressBar binds to.
	private readonly Task _updateTask;
	public Task UpdateTask
	{
		get { return _updateTask; }
	}
	public MainWindow()
	{
		// Instatiate task, hooking it up to the update event.
		_updateTask = new Task(ref UpdateProgressChanged);
	}
	private void OnUpdateProgressChanged(int progressPercentage)
	{
		if (UpdateProgressChanged != null)
		{
			UpdateProgressChanged(this, new ProgressChangedEventArgs(progressPercentage, null));
		}
	}
	// Simple progress simulation
	private void Button1_Click(object sender, RoutedEventArgs e)
	{
		int progress = 0;
		DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.5) };
		timer.Tick += (sSub,eSub) =>
		{
			progress++;
			// Raise progress changed event which in turn will change
			// the progress of the task which in turn will cause
			// the binding to update.
			OnUpdateProgressChanged(progress);
			if (progress == 100)
			{
				timer.Stop();
			}
		};
		timer.Start();
	}
