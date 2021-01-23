    abstract class ABase {
    
      public void DoSomething(object p)
      {
        p.Process();
        DoSomethingExtra(p);
      }
    
      public abstract void DoSomethingExtra(object p);
    }
