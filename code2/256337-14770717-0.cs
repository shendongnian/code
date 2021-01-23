	public static void InvokeIfNecessary (Action action)
	{
		if (Thread.CurrentThread == Application.Current.Dispatcher.Thread)
			action ();
		else {
			Instance.Invoke(action);
		}
	}
