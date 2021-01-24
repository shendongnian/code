    class Server {
        private TcpListener _server;
        private Boolean _isRunning = true;
        private int m_Port = 12001;
        private Thread m_ServerThread;
    
        public Server (int p_Port) {
            _server = new TcpListener(IPAddress.Any, m_Port);
            _server.Start( );            
        
            m_ServerThread = new Thread(new ThreadStart(LoopClients));
            m_ServerThread.Start( );
        }
        
        public void ShutdownServer() {
            _isRunning = false;
        }
        
        public void LoopClients ( ) {
            while ( _isRunning ) {
                // wait for client connection
                TcpClient newClient = _server.AcceptTcpClient( );
        
                // client found.
                // create a thread to handle communication
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }
    
        public void HandleClient (object obj) {
            try {
                // retrieve client from parameter passed to thread
                TcpClient client = (TcpClient) obj;
    
                // sets two streams
                StreamWriter sWriter = new StreamWriter(client.GetStream( ), Encoding.ASCII);
                StreamReader sReader = new StreamReader(client.GetStream( ), Encoding.ASCII);
                // you could use the NetworkStream to read and write, 
                // but there is no forcing flush, even when requested
                String sData = null;
                    
                while ( client.Connected ) {
                    sData = sReader.ReadToEnd( );
                    if ( sData != "" )
                        break;
                }
                    
                try {
                    sWriter.WriteLine("test");
                } catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
    
                sWriter.Dispose( );
                sReader.Dispose( );
                sWriter = null;
                sReader = null;
            } catch ( IOException ioe ) {
    
            }
        }
    }
