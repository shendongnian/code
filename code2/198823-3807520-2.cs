    using (TcpClient client = new TcpClient("localhost", 1234))
    using (StreamWriter writer = new StreamWriter(client.GetStream()))
    {
        writer.WriteLine("Have a message.");
        writer.Flush();
        writer.WriteLine("Have another message.");
        writer.Flush();
    }
