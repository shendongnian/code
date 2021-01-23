    protected CancellationTokenSource _tokenSource = null;
    protected Task _thread = null;
    protected override void OnStart(string[] args)
    {
        _tokenSource = new CancellationTokenSource();
        _thread = Task.Factory.StartNew(() => DoMyServiceLogic(), TaskCreationOptions.LongRunning, _tokenSource);
    }
    protected override void OnStop()
    {
         _tokenSource.Cancel();
    }
    protected void DoMyServiceLogic()
    {
         while(!_tokenSource.Token.IsCancellationRequested)
         {
             // Do Stuff
         }
    }
