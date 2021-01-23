    class ABase {
      public void DoSomething(object p)
      {
        p.Process();
        DoSomethingExtra(p); // Always call
      }
      public virtual void DoSomethingExtra(object p)
      {
          // Do nothing here
      }
    }
