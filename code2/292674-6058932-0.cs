    class myThread
    {
      private ManualResetEvent m_WaitHandle = new ManualResetEvent(false);
      public myThread
      {
        new Thread(Run).Start();
      }
      public void Shutdown()
      {
        m_WaitHandle.Set(); // Signal the wait handle.
      }
      private void Run()
      {
        while (!m_WaitHandle.WaitOne(INTERVAL)) // The waiting happens here.
        {
          // Some task
        }
        // If execution gets here then the wait handle was signaled from the Shutdown method.
      }
    }
