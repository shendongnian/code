	readonly Valve valve = new Valve();
	public void BeginInvoke(Action method)
	{
		pendingActions.Enqueue(method);
		if (valve.TryEnter())
			uiContext.Post(ProcessQueue, null);
	}
	private void ProcessQueue(object unused)
	{
		//This runs on the UI thread.
		Action current;
		while (pendingActions.TryDequeue(out current))
			current();
		valve.Exit();
	}
