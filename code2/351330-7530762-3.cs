    public class NormallyOpenTimedLatch
    {
        private TimeSpan m_Timeout;
        private bool m_Open = true;
        private object m_LockObject = new object();
        private DateTime m_TimeOfLastClose = DateTime.MinValue;
    
        public NormallyOpenTimedLatch(TimeSpan timeout)
        {
            m_Timeout = timeout;
        }
    
        public void Wait()
        {
            lock (m_LockObject)
            {
                while (!m_Open)
                {
                    Monitor.Wait(m_LockObject);
                }
            }
        }
    
        public void Open()
        {
            lock (m_LockObject)
            {
                m_Open = true;
                Monitor.PulseAll(m_LockObject);
            }
        }
    
        public void Close()
        {
            lock (m_LockObject)
            {
                m_TimeOfLastClose = DateTime.UtcNow;
                if (m_Open)
                {
                    new Timer(OnTimerCallback, null, (long)m_Timeout.TotalMilliseconds, Timeout.Infinite);
                }
                m_Open = false;
            }
        }
    
        private void OnTimerCallback(object state)
        {
            lock (m_LockObject)
            {
                TimeSpan span = DateTime.UtcNow - m_TimeOfLastClose;
                if (span > m_Timeout)
                {
                    Open();
                }
                else
                {
                    TimeSpan interval = m_Timeout - span;
                    new Timer(OnTimerCallback, null, (long)interval.TotalMilliseconds, Timeout.Infinite);
                }
            }
        }
    
    }
