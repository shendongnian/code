    private Thread _workerThread;
    private bool _closing = false;
    ... OnStart(...)
    {
         _workerThread = new Thread(new ThreadStart(Work));
         _workerThread .Start();
    
    }
    
    private void Work()
    {
        while(!_closing)
        {
        // do the processing if there is work otherwise sleep for say 10 seconds 
        }
    }
    
    
    ... OnStop(...)
    {
        _closing = true;
        _workerThread.Abort()
    }
