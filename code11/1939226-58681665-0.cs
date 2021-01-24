    void Accept()
    {
        var arg = new SocketAsyncEventArgs();
        arg.Completed += Accepted;
        try 
        { 
            bool done = server.AcceptAsync(arg);
            if (!done) Accepted(null, arg);
        }
        catch (Exception)
        {
            arg.Dispose();
            StopServer(null);
        }
    }
    void Accepted(object sender, SocketAsyncEventArgs e)
    {
        e.Completed -= Accepted;
        e.Completed += CheckInfo;
        SetBuffer(e, infoBufferLength);
        bool done = e.AcceptSocket.ReceiveAsync(e);
        if (!done) CheckInfo(null, e);
        Accept();
    }
