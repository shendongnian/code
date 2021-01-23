	foreach (var grp in unfilteredActions.GroupBy(k => k.UserName))
	{
		foreach(UserAction action in grp.Where(a => a.ExecutedOn > threshold))
		{
			Console.Out.WriteLine(String.Format("{0} {1} {2}", action.UserName, action.Action, action.ExecutedOn));
		}
	}
