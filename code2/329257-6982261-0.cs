    public class BaseObject {
      public delegate void del();
    
      public BaseObject() {
        next = Method;
      }
    
      public del next;
      public void Execute() {
        next();
      }
    
      public virtual void Method() {
        Console.WriteLine("base");
      }
    }
    
    public class InheritedObject : BaseObject {
    
      override public void Method() {
        Console.WriteLine("inherited");
      }
    
    }
