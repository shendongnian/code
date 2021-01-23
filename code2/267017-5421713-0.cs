    void StartListening()
    {
        _listener.BeginAccept(OnAccept, null);
    }
    void OnAccept(IAsyncResult res)
    {
        var clientSocket = listener.EndAccept(res);
 
        //begin accepting again
        _listener.BeginAccept(OnAccept, null);
       clientSocket.BeginReceive(xxxxxx, OnRead, clientSocket);
    }
    void OnReceive(IAsyncResult res)
    {
        var socket = (Socket)res.Asyncstate;
        var bytesRead = socket.EndReceive(res);
        socket.BeginReceive(xxxxx, OnReceive, socket);
        //handle buffer here.
    }
