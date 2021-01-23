    public class ClassA
    {
      private ClassB b = new ClassB();
    
      public void MethodA()
      {
        lock (b)
        {
          // Do anything you want with b here.
        }
      }
    
      public void MethodB()
      {
        lock (b)
        {
          // Do anything you want with b here.
        }
      }
    }
