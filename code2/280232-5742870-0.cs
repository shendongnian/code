    public void Start()
    {          
        TcpListener listener = new TcpListener(IPAddress.Any, 10250);
        listener.Start();
        Console.WriteLine("Listening...");
        while (canRun)
        {
           var client = listener.AcceptTcpClient();
           new Thread(ClientThread).Start(client);
        }
    }
    private void ClientThread(IAsyncResult res)
    {
        TcpClient client = (TcpClient)res.AsyncState;
        StringBuilder sb = new StringBuilder();
        var data = new byte[client.ReceiveBufferSize];
        using (NetworkStream ns = client.GetStream())
        {             
            // Test reply
            Byte[] replyData = System.Text.Encoding.ASCII.GetBytes(DateTime.Now.ToString());
            ns.Write(replyData, 0, replyData.Length);
            ns.Flush();
            ns.Close();
        }
        client.Close();
    }
