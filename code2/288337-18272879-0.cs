    public sealed class Singleton
    {
       private static volatile Singleton _instance;
       private static readonly object InstanceLoker= new Object();
    
       private Singleton() {}
    
       public static Singleton Instance
       {
          get 
          {
             if (_instance == null) 
             {
                lock (InstanceLoker) 
                {
                   if (_instance == null) 
                      _instance = new Singleton();
                }
             }
    
             return _instance;
          }
       }
    }
