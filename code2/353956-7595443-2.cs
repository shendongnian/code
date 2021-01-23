    void Main()
    {
    	try
    	{
    		using(var d = new MyDisposable())
    		{
    			throw new Exception("Hello");
    		}
    	}
    	catch
    	{
    		"Exception caught.".Dump();
    	}
    	
    }
    
    class MyDisposable : IDisposable
    {
    	public void Dispose()
    	{
    		"Disposed".Dump();
    	}
    }
