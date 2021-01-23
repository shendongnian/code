    class ProtocolListener
    {
        TcpListener m_listener;
        IProtocol   m_protocol = null;
        TcpClient   m_client = null;
        internal ProtocolListener(TcpListener listener, IProtocol protocol)
        {
            m_listener = listener;
            m_protocol = protocol;
        }
        internal void Start()
        {
            //
            // Block waiting for socket connection and then process.  Repeat in endless loop.
            //
            while (true)
            {
                try
                {
                    m_client = m_listener.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem (new WaitCallback(ProcessClientProtocol), m_protocol);
                }
                catch (SocketException se)
                {
                    // TODO: replace with logging and event log
                    Console.WriteLine("Exception = " +  se.Message);
                }
            }
        }
        private void ProcessClientProtocol (object protocol)
        {
            Debug.Assert(m_client != null);
            Debug.Assert(protocol != null);
            ((IProtocol)protocol).Client = m_client;
            ((IProtocol)protocol).ProcessClient();
        }
    }
