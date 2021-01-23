    public void AcceptClients()
    {
         TcpListener listener = new TcpListener(IPAddress.Any, 5566);
         listener.Start();
         while (_serverRunning)
         {
              var socket = listener.AcceptSocket();
              new Thread(ClientFunc).Start(socket);
         }
    }
    
    public void ClientFun(object state)
    {
        var clientSocket = (Socket)state;
        var buffer = new byte[65535];
        while (_serverRunning)
        {
            //blocking read.
            clientSocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
     
            //check packet.
    
            // handle packet
    
            // send respons.
            clientSocket.Send(alalalal);
        }
    }
