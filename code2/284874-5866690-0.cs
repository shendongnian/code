    public class RunOnceMethod
    {
      private bool haveIRunMyMethod = false
    
      public void ICanOnlyRunOnce()
      {
        if(haveIRunMyMethod)
          throw new InvalidOperationException("ICanOnlyRunOnce can only run once");
    
        // do something interesting
       
        this.haveIRunMyMethod = true;
      }
    }
