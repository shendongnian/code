    private void ListenerCallback()
    {  
        TcpListener listner = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12000));
        listner.Start();
        while (true)
        {
            TcpClient client = listner.AcceptTcpClient();
    
            StreamReader sr = new StreamReader(client.GetStream());
            MessageBox.Show($"Recieved data: {sr.ReadLine()}");
            client.Close();
    
            Thread.Sleep(500);
        }
    }
