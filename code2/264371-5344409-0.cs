    public abstract class Base
    {
      public int GetX(int arg)
      {
        // do boilerplate
    
        // call protected implementation
        var retVal = GetXImpl(arg);
        
        // perhaps to more boilerplate
      }
    
      protected abstract int GetXImpl(int arg);
    }
    
    public class MyClass : Base
    {
      protected override int GetXImpl(int arg)
      {
        // do stuff
      }
    }
