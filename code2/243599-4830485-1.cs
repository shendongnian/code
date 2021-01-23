    public class Cache
    {
        class CacheEntry
        {
            private Int64 m_Touched;
            public CacheEntry()
            {
                Touch();
            }
            public void Touch() 
            {
                System.Threading.InterlockedExchange(ref m_Touched, DateTime.Now.Ticks);
            }
            public DateTime Touched
            {
                get
                {
                    return DateTime(Interlocked.Read(ref m_Touched));
                }
            }
        } // eo class CacheEntry
    } // eo class Cache
