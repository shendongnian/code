	Action[] actions = new Action[]
	{
		ExternalDevice.Call1,
		ExternalDevice.Call2,
		ExternalDevice.Call3
	};
	foreach (Action action in actions)
	{
		try
		{
			action();
		}
		catch (Exception e)
		{
			// Error with this action()
		}
	}
