    TcpClient client = (TcpClient) connection;
        
    using(StreamWriter streamWriter = new StreamWriter(tcpClient.GetStream()))
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(streamWriter, savedObject);
    }
