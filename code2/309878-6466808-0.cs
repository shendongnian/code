	Task task = Task.Factory.StartNew
	(
		() =>
			{
				//Your action when the task started
			}
	);
	task.ContinueWith
	(
		_ =>
			{	
				//Your action when the task completed
			},
		CancellationToken.None,
		TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.AttachedToParent,
		TaskScheduler.FromCurrentSynchronizationContext()
	);
	task.ContinueWith
	(
		(t) =>
			{
				//Action when error occured
				Exception exception = null;
				if (t.Exception.InnerException != null)
				{
				exception = t.Exception.InnerException;
				}
				else
				{
				exception = t.Exception;
				}
				//You can use this exception
			},
		CancellationToken.None,
		TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.AttachedToParent,
		TaskScheduler.FromCurrentSynchronizationContext()
	);
