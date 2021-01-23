    // Enter the listening loop.
    while (true)
    {
        Debug.WriteLine("Waiting for a connection... ");
       
        client = server.AcceptTcpClient();
 
        ThreadPool.QueueUserWorkItem(new WaitCallback(HandleTcp), client);
    }
    private void HandleTcp(object tcpClientObject)
    {
        TcpClient client = (TcpClient)tcpClientObject;
        // Perform a blocking call to accept requests.
        data = new List<byte>();
        // Get a stream object for reading and writing
        using (NetworkStream stream = client.GetStream())
        {
            // Loop to receive all the data sent by the client.
            int length;
            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                var copy = new byte[length];
                Array.Copy(bytes, 0, copy, 0, length);
                data.AddRange(copy);
            }
        }
        receivedQueue.Add(data);
    } 
