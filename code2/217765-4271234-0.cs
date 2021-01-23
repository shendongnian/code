    public class CountdownWaitHandle : WaitHandle
    {
        private int m_Count = 0;
        private ManualResetEvent m_Event = new ManualResetEvent(false);
    
        public CountdownWaitHandle(int initialCount)
        {
            m_Count = initialCount;
        }
    
        public void AddCount()
        {
            Interlocked.Increment(ref m_Count);
        }
    
        public void Signal()
        {
            if (Interlocked.Decrement(ref m_Count) == 0)
            {
                m_Event.Set();
            }
        }
    
        public override bool WaitOne()
        {
            return m_Event.WaitOne();
        }
    }
