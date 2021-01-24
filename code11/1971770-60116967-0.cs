    public static void RunAndForget(this Task task, Action<Exception> onError)
	{
		task.ContinueWith(t => { onError?.Invoke(t.Exception); }, TaskContinuationOptions.OnlyOnFaulted);
	}
    //the Logging.LogException is a static Action so you can set it once
	public static void RunAndForget(this Task task)
	{
		task.ContinueWith(t => { Logging.LogException(t.Exception); }, TaskContinuationOptions.OnlyOnFaulted);
	}
