    void Process()
    {
        while (true)
        {
            if (timerReady.WaitOne(3 * 1000))
            {
              timerReady.Reset();
              //do worker action
              workerReady.Set();
            }
        }
    }
