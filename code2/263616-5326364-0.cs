    public void ReSync()
    {
      if (!m_IsResyncing)
      {
        lock (m_resyncLock)
        {
          if (!m_IsResyncing)
          {
            m_IsResyncing = true;
            Thread.Sleep(100); // sleep for 100ms to accumulate other locks
            // reinitialize here
            m_IsResyncing = false;
          }
        }
      }
    }
