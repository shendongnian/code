    Process[] processes = Process.GetProcessesByName("ProcessName");
    if (processes.Length > 1)
    {
        TcpClient client = new TcpClient();
        client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12000));
    
        StreamWriter sw = new StreamWriter(client.GetStream());
        sw.AutoFlush = true;
        sw.WriteLine($"addsong:{path}");
    
        client.Close();
    
        Process.GetCurrentProcess().Kill();
    }
    else
    {
        var thread = new Thread(ListenerCallback);
        thread.Start();
    }
