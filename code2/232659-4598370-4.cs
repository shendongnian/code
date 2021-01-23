    class Program
    {
    	static void Main(string[] args)
    	{
    		try
    		{
    			Test();
    		}
    		catch (Exception ex)
    		{
    			
    			// does not work properly - writes "Main"
    			Console.WriteLine(MethodBase.GetCurrentMethod());
    
    			// properly writes "TestConsole.Program.Test"
    			Console.WriteLine(GetExecutingMethodName(ex));
    
    			// properly writes "Test"
    			Console.WriteLine(ex.TargetSite.Name);
    		}
    
    		Console.ReadKey();
    	}
    
    
    	static void Test()
    	{
    		throw new Exception("test");
    	}
    
    	private static string GetExecutingMethodName(Exception exception)
    	{
    		var trace = new StackTrace(exception);
    		var frame = trace.GetFrame(0);
    		var method = frame.GetMethod();
    
    		return string.Concat(method.DeclaringType.FullName, ".", method.Name);
    	}
    }
