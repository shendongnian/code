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
    		
            if (result is IResult)
                result = new[] { result as IResult };
            if (result is IEnumerable<IResult>)
                Coroutine.Execute(((IEnumerable<IResult>) result).GetEnumerator(), context);
            else if (result is IEnumerator<IResult>)
                Coroutine.Execute(((IEnumerator<IResult>) result), context);
            
            return true;
    	}
    	catch
    	{
    	    return false;
    	}
    }
