    private void OnAccept(IAsyncResult ar)
    {
       bool beginAcceptCalled = false;
       try
       {
           //start the listener again
           _listener.BeginAcceptSocket(OnAccept, null);
           beginAcceptCalled = true;
           Socket socket = _listener.EndAcceptSocket(ar);
           //do something with the socket..
       }
       catch (Exception ex)
       {
           if (!beginAcceptCalled)
           {
              //try listening to connections again
              _listener.BeginAcceptSocket(OnAccept, null);
            }
        }
    }
