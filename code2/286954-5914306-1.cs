    ExternalMethod()
    {
        //some calculations
        var finished = new CountdownEvent(1);
        for (int i = 0; i < 10; i++)
        {
            finished.AddCount();
            ThreadPool.QueueUserWorkItem(
              () =>
              {
                try
                {
                  SomeMethod(i);
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
