    TcpListener listener = new TcpListener(IPAddress.Any, 1234);
    listener.Start();     
      
    using (TcpClient client = listener.AcceptTcpClient())
    using (StreamReader reader = new StreamReader(client.GetStream()))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
    listener.Stop();
