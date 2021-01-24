    await Task.WhenAll(tasks).ContinueWith((result) =>
    {
    	if (result.IsFaulted)
    	{
    		foreach (var e in result.Exception.InnerExceptions)
    		{
    			Console.WriteLine(e);
    		}
    	}
    });
