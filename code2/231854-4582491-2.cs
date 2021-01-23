    System.Threading.Thread t = new System.Threading.Thread(() =>
    {
        using(TcpClient client = new TcpClient())
        {
            client.Connect(ip, port);
            //followup code here
        }
    });
    t.Start();
