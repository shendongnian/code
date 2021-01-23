    void FirstThread()
    {
      lock (mre)
      {
        // Do stuff.
        mre.Set();
        // Do stuff.
      }
    }
    
    void SecondThread()
    {
      lock (mre)
      {
        // Do stuff.
        while (!CheckSomeCondition())
        {
          mre.WaitOne();
        }
        // Do stuff.
      }
    }
