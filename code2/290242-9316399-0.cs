    public class LazyInitRelaxedRef<T> where T : class
    {
        private volatile T m_value;
        private Func<T> m_factory;
        public LazyInitRelaxedRef(Func<T> factory) { m_factory = factory; }
        public T Value
        {
            get
            {
                if (m_value == null) 
                  Interlocked.CompareExchange(ref m_value, m_factory(), null);
                return m_value;
            }
        }
        /// <summary>
        /// An alternative version of the above Value accessor that disposes
        /// of garbage if it loses the race to publish a new value.  (Page 527.)
        /// </summary>
        public T ValueWithDisposalOfGarbage
        {
            get
            {
                if (m_value == null)
                {
                    T obj = m_factory();
                    if (Interlocked.CompareExchange(ref m_value, obj, null) != null && obj is IDisposable)
                        ((IDisposable)obj).Dispose();
                }
                return m_value;
            }
        }
    }
