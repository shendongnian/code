    static async Task StartChildTcpClientAsync(TcpClient tcpClient)
    {
        Console.WriteLine($"Connection received from: {tcpClient.Client.RemoteEndPoint.ToString()}");
        using var stream = tcpClient.GetStream();
        var buffer = new byte[1024];
        while (true)
        {
            var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            await stream.WriteAsync(buffer, 0, bytesRead);
        }
    }
