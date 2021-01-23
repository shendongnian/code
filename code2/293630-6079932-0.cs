    class Server
    {
        public Server()
        {
            TcpListener listener = null;
            // init the listener
            listener.BeginAcceptSocket((ar) => AcceptLoop(ar, listener),null);
        }
        public void HandleClientSocketRead(IAsyncResult ar, byte[] recvBuffer, Socket clientSocket)
        {
            int recvd = clientSocket.EndReceive(ar);
            //do something with the data
            clientSocket.BeginReceive(recvBuffer, 0, 1024, SocketFlags.None, (ar2) => HandleClientSocketRead(ar2, recvBuffer, clientSocket), null);
        }
        public void AcceptLoop(IAsyncResult ar, TcpListener listener)
        {
            Socket clientSocket = listener.EndAcceptSocket(ar); // note that this can throw
            byte[] recvBuffer = new byte[1024];
            clientSocket.BeginReceive(recvBuffer, 0, 1024, SocketFlags.None, (ar2) => HandleClientSocketRead(ar2, recvBuffer, clientSocket), null);
            
            listener.BeginAcceptSocket((ar) => AcceptLoop(ar, listener), null);
        }
    }
