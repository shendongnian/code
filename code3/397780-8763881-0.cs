    public static SSLStream Connect(ref string hostname, ref int port, bool useSsl) 
    {     
       TcpClient tcpClient = new TcpClient(hostname, port);
       if (!useSsl) 
       {
          return new Client(tcpClient.GetStream());
       }
       sslStream = new SslStream(tcpClient.GetStream()); // or the ref sslStream 
       sslStream.AuthenticateAsClient(hostname);
       tcpClient = null; or if implements IDisposable then do this
       if (tcpClient != null)
       {
          ((IDisposable)tcpClient).Dispose();
       }
       return sslStream; //if yo
    } 
