    ExternalMethod()
    {
        //some calculations
        var finished = new ManualResetEvent(false);
        int pending = 1;
        for (int i = 0; i < 10; i++)
        {
            int capture = i; // This is needed to capture the loop variable correctly.
            Interlocked.Increment(ref pending);
            ThreadPool.QueueUserWorkItem(
              (state) =>
              {
                try
                {
                  SomeMethod(capture);
                }
                finally
                {
                  if (Interlocked.Decrement(ref pending) == 0) finished.Set();
                }
              }, null);
        }
        if (Interlocked.Decrement(ref pending) == 0) finished.Set();
        finished.WaitOne();
        //continuation ExternalMethod
    }
