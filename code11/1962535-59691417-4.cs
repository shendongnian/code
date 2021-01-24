    static async Task StartTcpClientAsync(TcpClient tcpClient)
    {
        Console.WriteLine($"Connection from: [{tcpClient.Client.RemoteEndPoint}]");
        var stream = tcpClient.GetStream();
        var buffer = new byte[1024];
        while (true)
        {
            int x = await stream.ReadAsync(buffer, 0, 1024);
            Console.WriteLine($"[{tcpClient.Client.RemoteEndPoint}] _ " +
                $"read {x} bytes {System.Text.Encoding.UTF8.GetString(buffer)}");
        }
    }
