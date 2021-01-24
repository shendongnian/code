    public static bool ThrowSameException(params Action[] actions)
	{
		Exception[] exceptions = new Exception[actions.Length];
		for (int i = 0; i < actions.Length; i++)
		{
			Action action = actions[i];
			try
			{
				action();
				return false;
			}
			catch (Exception ex)
			{
				if (i > 0 && !ex.GetType().Equals(exceptions[i-1].GetType()))
					return false;
				exceptions[i] = ex;
			}
		}
		return true;
	}
