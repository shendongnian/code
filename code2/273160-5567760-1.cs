    private ManualResetEvent resetEvent = new ManualResetEvent(false);
    private RegisteredWaitHandle handle;
    public void OnStart()
    {
        resetEvent.Reset();
        handle = ThreadPool.RegisterWaitForSingleObject(resetEvent, callBack, null, 7200000, false);
    }
    public void OnStop()
    {
        reset.Set();
    }
    private void callBack(object state, bool timeout)
    {
        if (timeout)
        {
            //Do Stuff Here
        }
        else
        {
            handle.Unregister(null);
        }   
    }
