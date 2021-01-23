	int boolValue = 0;
	// ...
	if (System.Threading.Interlocked.Exchange(ref boolValue, 1) == 1)
	{
		// Was True
	}
	else
	{
		// Was False				
	}
