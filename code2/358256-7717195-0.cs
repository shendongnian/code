    ManualResetEvent _evtActor = new ManualResetEvent();
    public void Start()
    {
        this._evtActor.Reset();
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoStuff));
        int result = ManualResetEvent.WaitAny(
                        new WaitHandle[] { this._evtActor },
                        30 * 1000); // Wait 30sec
        if (result == ManualResetEvent.WaitTimeout)
        {
            Console.WriteLine("Timeout occurred!");
        }
        else
        {
            Console.WriteLine("Done!");
        }
    }
    public void DoStuff()
    {
        Console.WriteLine("Doing stuff.");
        Thread.Sleep(45 * 1000); // sleep for 45sec;
        this._evtActor.Set();
    }
