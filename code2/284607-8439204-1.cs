    private static Thread CreateDispatcherThread()
    {
        using (var startedEvent = new ManualResetEventSlim()) 
        {
            var dispatcherThread = new Thread( _ => { 
                Dispatcher.CurrentDispatcher.BeginInvoke((Action)(startedEvent.Set));
                Dispatcher.Run(); } );
            dispatcherThread.Start();
            startedEvent.WaitHandle.WaitOne();
            return dispatcherThread;
        }
    }   
