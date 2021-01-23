    private void BeginSend()
    {
        _clientState = EClientState.Sending;
        Encoding ASCII = Encoding.ASCII;
        string Get = "GET /" + _asyncTask.Path + " HTTP/1.1\r\nHost: " + _asyncTask.Host + "\r\nConnection: Keep-Alive\r\n\r\n";
        byte[] buffer = ASCII.GetBytes(Get);
 
        SocketAsyncEventArgs e = new SocketAsyncEventArgs();
        e.SetBuffer(buffer, 0, buffer.Length);
        e.Completed += new EventHandler<SocketAsyncEventArgs>(SendCallback);
 
        bool completedAsync = false;
 
        try
        {
            completedAsync = _socket.SendAsync(e);
        }
        catch (SocketException se)
        {
            Console.WriteLine("Socket Exception: " + se.ErrorCode + " Message: " + se.Message);
        }
 
        if (!completedAsync)
        {
            // The call completed synchronously so invoke the callback ourselves
            SendCallback(this, e);
        }
         
    }
