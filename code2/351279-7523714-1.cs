    using (var tcpClient = (TcpClient)client)
    using (var clientStream = tcpClient.GetStream())
    {
        // Store everything that the client sends.
        // This will work if the client closes the connection gracefully
        // after sending everything
        var receivedData = new MemoryStream();
        clientStream.CopyTo(receivedData);
        var rawBytes = receivedData.ToArray();
        var file = Encoding.ASCII.GetString(rawBytes, 0, rawBytes.Length);
        Menu.Insert(theDatabase, file);
    }
