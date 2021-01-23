    ExternalMethod()
    {
        //some calculations
        var finished = new CountdownEvent(1);
        for (int i = 0; i < 10; i++)
        {
            int capture = i; // This is needed to capture the loop variable correctly.
            finished.AddCount();
            ThreadPool.QueueUserWorkItem(
              (state) =>
              {
                try
                {
                  SomeMethod(capture);
                }
                finally
                {
                  finished.Signal();
                }
              }, null);
        }
        finished.Signal();
        finished.Wait();
        //continuation ExternalMethod
    }
