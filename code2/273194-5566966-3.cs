    public class Locker
    {
       private static object lockObject = new object(); 
       // a static doodad for locking
       public void Work()
       {
          lock (lockObject)
          {
             //do something
          }
       }
    }
    
