    byte[] bytesFrom = new byte[clientSocket.ReceiveBufferSize];
    using(var stream=clientSocket.GetStream())
    {
        var read=stream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
        var text = Encoding.ASCII.GetString(bytesFrom,0,read);
        Console.WriteLine("Actual Text: {0}",text);
    }
