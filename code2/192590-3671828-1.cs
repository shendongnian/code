    public class BlockingCollection<T>
    {
        private Queue<T> m_Queue = new Queue<T>();
    
        public T Take()
        {
            lock (m_Queue)
            {
                while (m_Queue.Count <= 0) Monitor.Wait(m_Queue);
                return m_Queue.Dequeue();
            }
        }
    
        public void Add(T value)
        {
            lock (m_Queue)
            {
                m_Queue.Enqueue(value);
                Monitor.Pulse(m_Queue);
            }
        }
    }
