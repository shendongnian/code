    static void Main(string[] args)
    {
    	if( args.Length < 1 )
    	{	
    		Console.WriteLine("usage: [method_name] ([arg0], ...)");
    		return;
    	}
    	
    	MyService s = new MyService();
    	
    	String methodName = args[0];
    	MethodInfo mi = s.GetType().GetMethod(methodName);
    	if( mi == null )
    	{
    		Console.WriteLine("no such method: " + methodName);
    		return;
    	}
    	
    	Type[] argTypes = mi.GetGenericArguments();
    	if( argTypes.Length != (args.Length - 1) )
    	{
    		Console.WriteLine("Invalid argument count");
    		return;
    	}
    	
    	Object[] methodArgs = new Object[argTypes.Length];
    	for( int ix = 0; ix < argTypes.Length; ix++ )
    	{
    		try
    		{
    			TypeConverter tc = TypeDescriptor.GetConverter(argTypes[ix]);
    			methodArgs[ix] = tc.ConvertFrom(args[ix + 1]);
    		}
    		catch
    		{
    			Console.WriteLine("Unable to convert from '" + args[ix + 1] + "' to " + argTypes[ix]);
    			return;
    		}
    	}
    	
    	Object result = mi.Invoke(s, methodArgs);
    	Console.WriteLine(result);
    }
