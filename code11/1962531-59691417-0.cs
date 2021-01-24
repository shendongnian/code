    static async Task StartTcpServerAsync()
    {
        var tcpListener = new TcpListener(new IPEndPoint(IPAddress.Any, 9999));
        tcpListener.Start();
        while (true)
        {
            var tcpClient = await tcpListener.AcceptTcpClientAsync();
            _ = StartTcpClientAsync(tcpClient);
        }
    }
