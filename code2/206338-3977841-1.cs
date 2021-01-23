    public class BlockingJobsCollection
    {
      private Queue<Job> m_Queue = new Queue<Job>();
     
      public void Add(Job item)
      {
        lock (m_Queue)
        {
          m_Queue.Enqueue(item);
          Monitor.Pulse(m_Queue);
        }
      }
    
      public Job Take()
      {
        lock (m_Queue)
        {
          while (m_Queue.Count == 0)
          {
            Monitor.Wait(m_Queue);
          }
          return m_Queue.Dequeue();
        }
      }
    }
