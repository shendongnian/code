    using System.Threading;
    //...
    public class TimerExample
    {
        private System.Threading.Timer m_objTimer;
        private bool m_blnStarted;
        private readonly int m_intTickMs = 1000;
        public TimerExample()
        {
            m_objTimer = new System.Threading.Timer(callback, m_objTimer, Timeout.Infinite, Timeout.Infinite);
        }
        public void Start()
        {
            if (!m_blnStarted)
            {
                m_blnStarted = true;
                m_objTimer.Change(m_intTickMs, Timeout.Infinite);
            }
        }
        public void Stop()
        {
            m_blnStarted = false;
        }
        private void callback(object state)
        {
            System.Diagnostics.Debug.WriteLine("callback invoked");
            //TODO: your code here
            Thread.Sleep(4000);
            m_objTimer.Change(m_intTickMs, Timeout.Infinite);
        }
    }
