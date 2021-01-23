    readonly object gate = new object();
    void Timer()
    {
        // do something
        ...
        // wait for the end "worker" iteration and then
        // pause "worker" until "timer function" is done
        lock (gate)
        {
            // do something more
            ...
        }
        // start the "worker" again
    }
    void Worker()
    {
        while (true)
        {
            lock (gate)
            {
                // do something
                ...
            }
            Thread.Sleep(3000);
        }
    }
