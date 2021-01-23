    ThreadPool.QueueUserWorkItem(_ =>
    {  
        dynamic clients = Hub.GetClients<KudzuHub>();
        TcpClient tcpClient = null;
        NetworkStream clientSockStream = null;
    
        try
        {
            string host = ConfigurationManager.AppSettings["receiverIP"].ToString();
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["receiverPort"]);
    
            while (true)
            {
                if (tcpClient == null) {
                  tcpClient = new TcpClient(host, port);
                  clientSockStream = tcpClient.GetStream();
                }
    
                if (clientSockStream.CanRead) {
                    byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
                    clientSockStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);
    
                    tcpClient.Close();
                    // Closing the client does not automatically close the stream
                    clientSockStream.Close();
    
                    tcpClient = null;
                    clientSockStream = null;
    
                    clients.addMessage(System.Text.Encoding.ASCII.GetString(bytes));
                }
                Thread.Sleep(50);
            }
        }
        catch (SocketException ex)
        {
            // do something to handle the error
        } finally {
           if (tcpClient != null) {
             tcpClient.Close();
             clientSockStream.Close();
           }
        } 
    
    });
