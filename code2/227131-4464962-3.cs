    public class PriorityBlockingQueue<TKey, TValue>
    {
        private SortedDictionary<TKey, TValue> m_Dictionary = new SortedDictionary<TKey,TValue>();
    
        public void Add(TKey key, TValue value)
        {
            lock (m_Dictionary)
            {
                m_Dictionary.Add(key, value);
                Monitor.Pulse(m_Dictionary);
            }
        }
    
        public TValue Take(TKey key)
        {
            TValue value;
            TryTake(key, TimeSpan.FromTicks(long.MaxValue), out value);
            return value;
        }
    
        public bool TryTake(TKey key, TimeSpan timeout, out TValue value)
        {
            value = default(TValue);
            DateTime initial = DateTime.UtcNow;
            lock (m_Dictionary)
            {
                while (!m_Dictionary.TryGetValue(key, out value))
                {
                    if (m_Dictionary.Count > 0) Monitor.Pulse(m_Dictionary); // Important!
                    TimeSpan span = timeout - (DateTime.UtcNow - initial);
                    if (!Monitor.Wait(m_Dictionary, span))
                    {
                        return false;
                    }
                }
                m_Dictionary.Remove(key);
                return true;
            }
        }
    }
