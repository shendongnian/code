    private void OnAccept(IAsyncResult ar)
    {
       bool beginAcceptCalled = false;
       try
       {
           //start the listener again
           _listener.BeginAcceptSocket(OnAccept, null);
           beginAcceptCalled = true;
           Socket socket = _listener.EndAcceptSocket(ar);
           socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 15 * 60 * 1000);
       }
       catch (Exception ex)
       {
           Logger.Error(string.Empty, ex);
           if (!beginAcceptCalled)
           {
              //try listening to connections again
              _listener.BeginAcceptSocket(OnAccept, null);
            }
        }
