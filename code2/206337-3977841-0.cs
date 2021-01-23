    public class BlockingJobsCollection
    {
      private List<Job> m_List = new List<Job>();
      private ManualResetEvent m_Signal = new ManualResetEvent(false);
     
      public void Add(Job item)
      {
        lock (m_List)
        {
          m_List.Add(item);
          m_Signal.Set();
        }
      }
    
      public Job Take()
      {
        while (true)
        {
          lock (m_List)
          {
            if (m_List.Count > 0)
            {
              Job item = m_List.First();
              m_List.Remove(item);
              if (m_List.Count == 0)
              {
                m_Signal.Reset();
              }
              return item;
            }
          }
          m_Signal.WaitOne();
        }
      }
    } 
