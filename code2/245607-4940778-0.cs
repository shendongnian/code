    protected override bool HandleException(ActionExecutionContext context,
                                            Exception ex)
    {
    	var method = context.Target
                            .GetType()
                            .GetMethod(MethodName, new[] { typeof(Exception) });
    	if (method == null) return false;
    
    	try
    	{
    		var result = method.Invoke(context.Target, new object[] { ex });
    
    		if (result is bool)
    			return (bool) result;
    		else if (result is IResult)
    			(result as IResult).Execute(context);
    		else if (result is IEnumerable<IResult>)
    			new SequentialResult((result as IEnumerable<IResult>)
                                             .GetEnumerator())
                                   .Execute(context);
    
    		return true;
    	}
    	catch
    	{
    		return false;
    	}
    }
