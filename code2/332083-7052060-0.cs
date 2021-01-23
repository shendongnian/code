    private string CmdArgsFromParameters(CompilerParameters options)
    {
    	StringBuilder stringBuilder = new StringBuilder(128);
    	// ...
    	StringEnumerator stringEnumerator = options.EmbeddedResources.GetEnumerator();
    	try
    	{
    		while (stringEnumerator.MoveNext())
    		{
    			string str = stringEnumerator.Current;
    			stringBuilder.Append("/res:\"");
    			stringBuilder.Append(str);
    			stringBuilder.Append("\" ");
    		}
    	}
    	finally
    	{
    		IDisposable disposable2 = stringEnumerator as IDisposable;
    		if (disposable2 != null)
    		{
    			disposable2.Dispose();
    		}
    	}
    	// ...
    	return stringBuilder.ToString();
    }
