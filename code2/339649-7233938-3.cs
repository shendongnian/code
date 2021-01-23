    class ABase {
    
      public virtual bool ShouldDoSomethingExtra { get { return false; } }
    
      public void DoSomething(object p)
      {
        p.Process();
        if(ShouldDoSomethingExtra)
          DoSomethingExtra(p);
      }
      public virtual void DoSomethingExtra(object p) { // Empty in base }
    }
    class ADerived {
      public override void DoSomethingExtra(object p)
      {
        p.ProcessMore();
      }
      public override bool ShouldDoSomethingExtra { get { return true; } }
    }
