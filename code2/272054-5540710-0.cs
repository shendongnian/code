    private ManualResetEvent mre = new ManualResetEvent(false);
    public void DoSomething(Action<int> actionToPerformOnComplete)
    {
       // Hook up an event handler to OnFinish()
       DoSomethingAsync(delegate(int val)
       {
          actionToPerformOnComplete(val);
       });
       mre.WaitOne();
    }
    
    public void OnFinish(object sender, SomeEventArgs args)
    {
       mre.Set();
    }
