    public Message Receive()
    {
        try
        {
            if (_tcpClient == null || !_tcpClient.Connected)
            {
                throw new TransportException("Client Not Connected");
            }
    
            using (var stream = _tcpClient.GetStream())
            using (var reader = new BinaryReader(stream))
            {
                int size = reader.ReadInt32();
                byte[] buffer = reader.ReadBytes(size);
                using (var memStream = new MemoryStream(buffer))
                {
                    var formatter = new BinaryFormatter();
                    return (Message)formatter.Deserialize(memStream);
                }
            }
        }
        catch (System.Exception e)
        {
            if (_tcpClient == null || !_tcpClient.Connected)
            {
                throw new TransportException("Client Not Connected");
            }
            throw e;
        }
    }
