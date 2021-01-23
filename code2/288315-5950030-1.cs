    public class UtilityClass
    {
      //
      // Resources
      //
    
      // r1 will be initialized by the static constructor
      static Resource1 r1 = null;
    
      // r2 will be initialized first, as static constructors are 
      // invoked after the static variables are initialized
      static Resource2 r2 = new Resource2();
    
      static UtilityClass()
      {
        r1 = new Resource1();
      }
    
      static void f1(){}
      static void f2(){}
    }
