    public abstract class Base
    {
      // other stuff
    
      public static void StaticMethod()
      {
        PrivateMethod();
      }
      // here should be PrivateMethod() declaration somehow
      private static void PrivateMethod()
      {
        // do stuff
      }
    }
    public sealed class Derived: Base
    {
      // other stuff
    
      public void InstanceMethod()
      {
        // call somehow PrivateMethod 
        StaticMethod(); 
      }
    }
