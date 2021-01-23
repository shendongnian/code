    using System.Threading;
    //...
    public class TimerExample
    {
        private System.Threading.Timer m_objTimer;
        private bool m_blnStarted;
        private readonly int m_intTickMs = 1000;
        private object m_objLockObject = new object();
        public TimerExample()
        {
            //Create your timer object, but don't start anything yet
            m_objTimer = new System.Threading.Timer(callback, m_objTimer, Timeout.Infinite, Timeout.Infinite);
        }
        public void Start()
        {
            if (!m_blnStarted)
            {
                lock (m_objLockObject)
                {
                    if (!m_blnStarted) //double check after lock to be thread safe
                    {
                        m_blnStarted = true;
                        //Make it start in 'm_intTickMs' milliseconds, 
                        //but don't auto callback when it's done (Timeout.Infinite)
                        m_objTimer.Change(m_intTickMs, Timeout.Infinite);
                    }
                }
            }
        }
        public void Stop()
        {
            lock (m_objLockObject)
            {
                m_blnStarted = false;
            }
        }
        private void callback(object state)
        {
            System.Diagnostics.Debug.WriteLine("callback invoked");
            //TODO: your code here
            Thread.Sleep(4000);
            //When your code has finished running, wait 'm_intTickMs' milliseconds
            //and call the callback method again, 
            //but don't auto callback (Timeout.Infinite)
            m_objTimer.Change(m_intTickMs, Timeout.Infinite);
        }
    }
