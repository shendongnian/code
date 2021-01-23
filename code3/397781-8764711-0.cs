    public class Client : IDisposable
    {
        private TcpClient tcpClient = null;
        public Client(string hostname, int port, bool useSsl) // c'tor
        {
            tcpClient = new TcpClient(hostname, port);
            if (!useSsl)
            {
                Init(tcpClient.GetStream());
                return;
            }
            SslStream sslStream = new SslStream(tcpClient.GetStream());
            sslStream.AuthenticateAsClient(hostname);
            Init(sslStream);            
        }
        private void Init(Stream stream)
        {
            // bla bla bla
        }
    
        public void Dispose()
        {  
            // this implementation of Dispose is potentially faulty (it is for illustrative purposes only)
            // http://msdn.microsoft.com/en-us/library/ms244737%28v=vs.80%29.aspx
            if( tcpClient != null ) {
                tcpClient.Close();
                tcpClient = null;
            }
        }
    }
