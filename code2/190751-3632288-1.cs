    abstract class StateMachine : IDisposable
    {
        public abstract IEnumerable<object> Main();
        
        public virtual void Dispose()
        {
            /// ... override with free-ing code ...
       }
    
       bool wasCancelled;
    
       public bool Cancel()
       {
         // ... set wasCancelled using locking scheme of choice ...
        }
    
       public Thread Run()
       {
           var thread = new Thread(() =>
               {
                  try
                  {
                    if(wasCancelled) return;
                    foreach(var x in Main())
                    {
                        if(wasCancelled) return;
                    }
                  }
                  finally { Dispose(); }
               });
           thread.Start()
       }
    }
    
    class MyStateMachine : StateMachine
    {
       public override IEnumerabl<object> Main()
       {
           DoSomething();
           yield return null;
           DoSomethingElse();
           yield return null;
       }
    }
    
    // then call new MyStateMachine().Run() to run.
