    var waitHandles = new ManualResetEvent[10];
    for (int i = 0; i < 10; i++)
    {
        waitHandles[i] = new ManualResetEvent(false);
        new Thread(waitHandle =>
        {
            // TODO: Do some processing...
            
            // signal the corresponding wait handle
            // ideally wrap the processing in a try/finally
            // to ensure that the handle has been signaled
            (waitHandle as ManualResetEvent).Set();
        }).Start(waitHandles[i]);
    }
    // wait for all handles to be signaled => this will block the main
    // thread until all the handles have been signaled (calling .Set on them)
    // which would indicate that the background threads have finished
    // We also define a 30s timeout to avoid blocking forever
    if (!WaitHandle.WaitAll(waitHandles, TimeSpan.FromSeconds(30)))
    {
        // timeout
    }
