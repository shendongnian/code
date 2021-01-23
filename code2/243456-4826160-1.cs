    public sealed class Singleton
    {
    	private Singleton()
    	{
    	   // Initialize here
    	}
     
    	private static volatile Singleton _singletonInstance;
     
    	private static readonly Object syncRoot = new Object();
     
    	public static Singleton GetInstance()
    	{
    	   if(_singletonInstance == null)
    	   {
    	      lock(syncRoot))
    	      {
    	         if(_singletonInstance == null)
    	         {	
    	            _singletonInstance = new Singleton();
    		 }
    	      }
    	   }
    
    	   return _singletonInstance;
    	}
    }
  
