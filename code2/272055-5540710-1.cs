    public void DoSomething(Action<int> actionToPerformOnComplete)
    {
       ManualResetEvent mre = new ManualResetEvent(false);
       DoSomethingAsync(delegate(int val)
       {
          try
          {
             actionToPerformOnComplete(val);
          }
          finally
          {
             mre.Set();
          }
       });
       mre.WaitOne();
    }
