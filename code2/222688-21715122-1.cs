    class HardAborter
    {
      public bool WasAborted { get; private set; }
      private CancellationTokenSource Canceller { get; set; }
      private Task<object> Worker { get; set; }
      public void Start(Func<object> DoFunc)
      {
        WasAborted = false;
        // start a task with a means to do a hard abort (unsafe!)
        Canceller = new CancellationTokenSource();
        Worker = Task.Factory.StartNew(() => 
          {
            try
            {
              // specify this thread's Abort() as the cancel delegate
              using (Canceller.Token.Register(Thread.CurrentThread.Abort))
              {
                return DoFunc();
              }
            }
            catch (ThreadAbortException)
            {
              WasAborted = true;
              return false;
            }
          }, Canceller.Token);
      }
      public void Abort()
      {
        Canceller.Cancel();
      }
    }
