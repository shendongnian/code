    protected bool _continueRunning = true;
    protected Task _thread = null;
    protected override void OnStart(string[] args)
    {
        _thread = Task.Factory.StartNew(() => DoMyServiceLogic(), TaskCreationOptions.LongRunning);
    }
    protected override void OnStop()
    {
        _continueRunning = false;
        _thread.Wait();
    }
    protected void DoMyServiceLogic()
    {
         while(_continueRunning)
         {
             // Do Stuff
         }
    }
