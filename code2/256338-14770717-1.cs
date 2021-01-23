	public static void InvokeIfNecessary (Action action)
	{
		if (Thread.CurrentThread == Application.Current.Dispatcher.Thread)
			action ();
		else {
			Application.Current.Dispatcher.Invoke(action);
		}
	}
