    public class BlockingQueue<T>
    {
      private Queue<T> m_Queue = new Queue<T>();
    
      public void Enqueue(T item)
      {
        lock (m_Queue)
        {
          m_Queue.Enqueue(item);
          Monitor.Pulse(m_Queue);
        }
      }
      
      public T Dequeue()
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
