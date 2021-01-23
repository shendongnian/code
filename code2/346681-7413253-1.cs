	foreach (byte b in bytes)
	{
		try
		{
			result.Add(GetVersion(b));
		}
		catch (UnexpectedQueryException e)
		{
			// this is where your exception handling starts
			// display an error, log the exception, ...
		}
	}
