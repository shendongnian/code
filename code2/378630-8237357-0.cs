	public void ExistingMethod()
	{
		// bad code
		// bad code
		throw new NullReferenceException("The previous developers are always the problem.");
	}
	…
	public void MyMethod(ComponentFromOldCode component)
	{
		try
		{
			component.ExistingMethod();
		}
		catch (NullReferenceException nre)
		{
			// do something
		}
		catch (Exception ex)
		{
			// do something
		}
	}
