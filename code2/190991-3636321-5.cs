    private Queue<object> m_Data = new Queue<object>();
    
    private void YourTimer_Tick(object sender, EventArgs args)
    {
      lock (m_Data)
      {
        while (m_Data.Count > 0)
        {
          object data = m_Data.Dequeue();
          // Add data to your grid here.
        }
      }
    }
    
    void WorkerThread()
    {
      while (true)
      {
        object data = GetNewData();
        lock (m_Data)
        {
          m_Data.Enqueue(data);
        }
      }
    }
