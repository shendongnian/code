    public class Your_Session
    {
        private TcpClient m_pClient = null;
        public Your_Session(TcpClient client)
        {
            mpClient = clint;
        }
        internal void Start(Object state)
        {
            // NOTE: call this Start method: 
            // ThreadPool.QueueUserWorkItem(new WaitCallback(session.Start));
            // Start your session processing here. This method is called from threapool thread. 
        }
    }
