    public void Start()
    {          
        TcpListener listener = new TcpListener(IPAddress.Any, 10250);
        listener.Start();
        Console.WriteLine("Listening...");
        listener.BeginAcceptTcpClient(OnAccept, listener);
    }
    private void OnAccept(IAsyncResult res)
    {
        TcpListener listener = (TcpListener)res.AsyncState;
        TcpClient client = listener.EndAcceptTcpClient(res);
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
