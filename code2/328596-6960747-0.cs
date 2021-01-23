    public static void Main()
    {
    	Action<string> errorTarget = delegate(string s) { Console.WriteLine(s); }; 
    	
    	SomeFunction(errorTarget);
    }
    
    private static void SomeFunction(Action<string> errorTarget)
    {
    	...
    	// Send non-fatal errors to the errorTarget
    	if (result == null)
    	{
    		// Build the error message, then call errorTarget
    		errorTarget(errorMessage);
    	}
    	...
    }
