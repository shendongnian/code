    TcpListener tcpListener = new TcpListener(1234);
    tcpListener.Start();     
      
    using (TcpClient client = server.AcceptTcpClient())
    using (StreamReader reader = new StreamReader(client.GetStream()))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
    tcpListener.Stop();
