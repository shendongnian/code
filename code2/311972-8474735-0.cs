    using (var client = new TcpClient())
    {
        client.Connect(serverIp, port));
        using (var w = new StreamWriter(client.GetStream()))
            w.Write("Here comes the message");
    }
