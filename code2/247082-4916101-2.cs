    private void TryElseThrow<TCustomException>(Action codeThatMightFail)
    	where TCustomException : Exception
    {
    	try
    	{
    		codeThatMightFail();
    	}
    	catch (Exception e)
    	{
    		// Since there isn't a generic type constraint for a constructor
    		// that expects a specific parameter, we'll have to risk it :-)
    		throw
    		  (TCustomException)Activator
    		    .CreateInstance(typeof(TCustomException), e);
    	}
    }
