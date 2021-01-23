    using (var file = File.OpenRead("<path to file>"))
    using (var client = new TcpClient("<server>", <port>))
    {
        ...
        file.CopyTo(client.GetStream());
        ...
    }
