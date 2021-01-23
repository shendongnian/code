    public static TResult TryGetOrDefault<TSource, TResult>(this TSource obj, Func<TSource, TResult> expression)
    {
    	if (obj == null)
    		return default(TResult);
    	
    	try
    	{
    		return expression(obj);
    	}
    	catch(NullReferenceException)
    	{
    		return default(TResult);
    	}
    }
