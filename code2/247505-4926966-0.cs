    try
    {
    	enumerator = list.GetEnumerator();
    	while (enumerator.MoveNext())
    	{
    		string str8 = Conversions.ToString(enumerator.Current);
    		//...
    	}
    }
    finally
    {
    	if (enumerator is IDisposable)
    	{
    		(enumerator as IDisposable).Dispose();
    	}
    }
