    public class MySingletonWithConstructor
    {
    	private static _instance;
    	private static object _lock = new Object();
    	
    	private MySingletonWithConstructor(string myArg) 
    	{
    		// ... do whatever necessary
    	}
    	
    	public static MySingletonWithConstructor Instance
    	{
    		get
    		{
    			if(_instance==null)
    			{
    				lock(_lock)
    				{
    					if(_instance==null) // double if to prevent race condition
    					{
    						_instance = new MySingletonWithConstructor("Something");
    					}
    				}
    			}
    			return _instance;
    		}
    	}
    
    }
