    public static bool AllThrowSameException(params Action[] actions)
	{
		Type lastExceptionType = null;
	    foreach (Action action in actions)
		{
			try
			{
				action();
				return false;
			}
			catch (Exception ex)
			{
				if (lastExceptionType?.Equals(ex.GetType()) == false)
					return false;
                lastExceptionType = ex.GetType();
			}
		}
		return true;
	}
