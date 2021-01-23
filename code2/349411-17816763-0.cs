    public class Listener
    {
        private readonly TcpListener m_Listener = new TcpListener(IPAddress.Any, IPEndPoint.MinPort);
        private CancellationTokenSource m_Cts;
        private Thread m_Thread;
        private readonly object m_SyncObject = new object();
    
        public void Start()
        {
            lock (m_SyncObject){
                if (m_Thread == null || !m_Thread.IsAlive){
                    m_Cts = new CancellationTokenSource();
                    m_Thread = new Thread(() => Listen(m_Cts.Token))
                        {
                            IsBackground = true
                        };
                    m_Thread.Start();
                }
            }
        }
    
        public void Stop()
        {
            lock (m_SyncObject){
                m_Cts.Cancel();
                m_Listener.Stop();
            }
        }
    
        private void Listen(CancellationToken token)
        {
            m_Listener.Start();
            while (!token.IsCancellationRequested)
            {
                try{
                    var socket = m_Listener.AcceptSocket();
                    //do something with socket
                }
                catch (SocketException){                    
                }
            }
        }
    }
