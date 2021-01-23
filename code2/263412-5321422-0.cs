    public class Test()
    {
       private static Object lockObjectAll = new Object();
       private Object lockObjectInstance = new Object();
    
       public void FooBar()
       {
           lock (lockObjectAll)
           {
              // Thread safe for all instances
           }
           lock (lockObjectInstance)
           {
              // Thread safe for 'this' instance
           }
       }
    }
