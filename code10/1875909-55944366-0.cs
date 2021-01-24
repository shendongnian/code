    public async Task InitNetwork()
    {
        while( true )
        {
            TcpClient newclient = await socket.AcceptTcpClientAsync();
            Task.Run( () => HandleClient.CreateConnection( newclient ) );
        }
    }
