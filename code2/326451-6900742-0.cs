    void Main()
    {
    	bool success = false;
    	SurroundJob.Embed(ref success, "facebook.com", DoCoreJob);
    }
    
    Boolean DoCoreJob(string Target)
    {
    	Boolean isHappy = false;
    	Console.WriteLine(@"http://" + Target);
    	isHappy = true;
    	return isHappy;
    }
    
    class SurroundJob
    {
    	public static void Embed<T, TResult>(ref TResult Result, T param,  Func<T, TResult> method)
    	{
    		if(method != null)
    		{
    			try
    			{
    				Log(param.ToString());
    				Result = method(param);
    			}
    			catch(Exception e)
    			{
    				Troubleshoot(param.ToString(), e);
    			}
    		}
    	}
    	
    	public static void Log(string s)
    	{
    		Console.WriteLine("Log: " + s);
    	}
    	
    	public static void Troubleshoot(string s, Exception e)
    	{
    		Console.WriteLine("Troubleshoot: " + s);
    		Console.WriteLine(e.ToString());
    	}
    }
