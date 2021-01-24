    static async Task Main(string[] args)
    {
        _ = StartTcpServerAsync();
        await Task.Delay(2000);
        await RunSenderAsync();
    }
    static async Task RunSenderAsync()
    {
        var tcpClient = new TcpClient("127.0.0.1", 9999);
        var s = tcpClient.GetStream();
        tcpClient.NoDelay = true;
        for (var i = 65; i < 91; i++)
        {
            s.Write(BitConverter.GetBytes(i), 0, 1);
            await Task.Delay(1000);
        }
    }
