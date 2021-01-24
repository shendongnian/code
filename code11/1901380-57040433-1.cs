    public static bool ThrowSameException(Action action1, Action action2)
	{
		Exception exc1 = null;
		Exception exc2 = null;
		try
		{
			action1();
		}
		catch (Exception ex)
		{
			exc1 = ex;
		}
		try
		{
			action2();
		}
		catch (Exception ex)
		{
			exc2 = ex;
		}
		if (exc1 == null || exc2 == null)
			return false;
		return exc1.GetType().Equals(exc2.GetType());
	}
