    private bool _running = true;
    private readonly byte[] _data = new byte[4096];
    private Socket _mainSocket;
    public void Capture()
    {
         _mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
         _mainSocket.Bind(new IPEndPoint(Utilities.GetLocalIP(), 0));
         _mainSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
         _running = true;
         _mainSocket.BeginReceive(_data, 0, _data.Length, SocketFlags.None, OnReceive, null);
         var byTrue = new byte[] {1, 0, 0, 0};
         var byOut = new byte[] {1, 0, 0, 0};
         _mainSocket.IOControl(IOControlCode.ReceiveAll, byTrue, byOut);
    }
    public void Stop()
    {
         _running = false;
         _mainSocket.Shutdown(SocketShutdown.Both);
         // Disposing of any remaining data that might've stayed behind
         // http://vadmyst.blogspot.be/2008/04/proper-way-to-close-tcp-socket.html
         try
         {
             while ((_mainSocket.Receive(_data)) > 0)
             {
             }
         }
         catch
         {
             //ignore
         }
         _mainSocket.Close();
    }
    private void OnReceive(IAsyncResult ar)
    {
         if (_running)
         {
             SocketError error;
             var received = _mainSocket.EndReceive(ar, out error);
             // Handle data
                
             if (_running)
             {
                 _mainSocket.BeginReceive(_data, 0, _data.Length, SocketFlags.None, OnReceive, null);
             }                
         }
    }
