        public void Start()
        {
            m_protocol = LoadProtocolPlugIn();
            // Create a TcpListener to accept client connection requests
            TcpListener tcpListener = new TcpListener(m_address, m_port);
            tcpListener.Start();
            //
            // Create a protocol listener per thread
            //
            for (int i = 0; i < m_listeners; i++)
            {
                ProtocolListener listener = new ProtocolListener(tcpListener, m_protocol);
                Thread thread = new Thread(new ThreadStart(listener.Start));
                thread.Start();
                Console.WriteLine("Listening on thread: {0}", thread.Name);
            }
            m_state = ServerState.Started;
        }
