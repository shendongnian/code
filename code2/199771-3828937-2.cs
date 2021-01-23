    public static void DoSomething<T>(ref T args)
    {
    	Exception e = args.GetType().GetProperty("Exception").GetValue(args, null) as Exception;
    
    	if (e != null)
    	{
    		//do something with an exception
    
    		typeof(CommonAncestorForDVArgs).GetProperty("ExceptionHandled").SetValue(args, true, null);
    	}
    }
