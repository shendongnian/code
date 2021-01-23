    using (var client = new TcpClient("localhost", 8888))
    using (var clientStream = client.GetStream())
    {
        var buffer = Encoding.ASCII.GetBytes( File.ReadAllText("FirstNames.txt") );
        clientStream.Write(buffer, 0, buffer.Length);
        buffer = Encoding.ASCII.GetBytes( File.ReadAllText("LastNames.txt") );
        clientStream.Write(buffer, 0, buffer.Length);
    }
