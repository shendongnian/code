    Queue<Person> serverQueue;   // This is the server side queue
    
    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 15884);
    TcpListener tcpListener = new TcpListener(ipEndPoint);
    tcpListener.Start();
    
    while(true)
    {
        TcpClient tcpClient = tcpListener.AcceptTcpClient();
        NetworkStream clientStream = tcpClient.GetStream();
    
        while (client.Connected)
        {
            if (client.Available >= 4)
            {
                try
                {
                     byte[] readDataLen = new byte[4];
                     clientStream.Read(readDataLen, 0, 4);
    
                     Int32 dataLen = BitConverter.ToInt32(readDataLen, 0);
                     byte[] readData = new byte[dataLen];
    
                     clientStream.Read(readData, 0, dataLen);
    
                     using (var memoryStream = new MemoryStream())
                     {
                          memoryStream.Write(readData, 0, readData.Length);
                          memoryStream.Position = 0;    /// This is very important. It took 4 hrs to identify an error because of this :)
    
                          BinaryFormatter bf = new BinaryFormatter();
                          Person person = (Person)bf.Deserialize(memoryStream);
                      
                          serverQueue.Enqueue(person);
                     }
                }
                catch { }
            }
        }
        tcpClient.Close();
    }
