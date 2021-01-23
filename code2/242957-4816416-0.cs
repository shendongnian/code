    // create an un-signalled AutoResetEvent
    AutoResetEvent _waitForResponse = new AutoResetEvent(false);
    
    void YourNewWorkerMethod()
    {
        _delayedResponse = null;
        var result = DoStuff();
        // this causes the current thread to wait for the AutoResetEvent to be signalled
        // ... the parameter is a timeout value in milliseconds
        if (!_waitForResponse.WaitOne(5000))
            throw new TimeOutException();
        return _delayedResponse;
    }
    private void OnResponseArrived(object sender, ResponseEventArgs args)
    {
        _delayedResponse = args.VerificationResponse;
        _waitForResponse.Set();  // this signals the waiting thread to continue...
    }
