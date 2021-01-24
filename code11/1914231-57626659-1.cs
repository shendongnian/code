	SynchronizationContext syncContext = null;
	void onIdle(object s, EventArgs e) {
		Application.Idle -= onIdle;
		syncContext = SynchronizationContext.Current;
		// make the task scheduler available
		schedulerTcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
	};
	Application.Idle += onIdle;
	Application.Run(createForm());
	SynchronizationContext.SetSynchronizationContext(null);
	(syncContext as IDisposable)?.Dispose();
