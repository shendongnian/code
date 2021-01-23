    TcpListener server = null;
    private void listen_data()
    {
        Int32 port = controller_port;
        IPAddress localAddr = IPAddress.Parse(this_ip);
        server = new TcpListener(localAddr, port);
        server.Start();
        while (true)
        {
            Console.Write("Waiting for a connection...-- ");
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("new client connected");
            ThreadPool.QueueUserWorkItem(HandleClient(client));//or use Task if 4.0 or new Thread...
        }
    }
    private void HandleClient(TcpClient client)
    {
        Byte[] bytes = new Byte[256];
        String data = null;
        int i;
        
        NetworkStream stream = client.GetStream();
        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
        {
            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
        }
            
        Console.WriteLine(data);
    }
