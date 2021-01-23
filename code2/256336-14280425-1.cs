    Dispatcher _myDispatcher;
    
    public void UnknownThreadCalling()
    {
        if (_myDispatcher.CheckAccess())
        {
            // Calling thread is associated with the Dispatcher
        }
    
        try
        {
            _myDispatcher.VerifyAccess();
    
            // Calling thread is associated with the Dispatcher
        }
        catch (InvalidOperationException)
        {
            // Thread can't use dispatcher
        }
    }
