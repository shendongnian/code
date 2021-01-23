    Queue<Person> clientQueue;   // This is the client side queue
    
    IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 15884);
    var client = new TcpClient();
    
    NetworkStream clientStream = client.GetStream()
    
    while (disconnectClient)
    {
        if (clientQueue.Count > 0)
        {
             Person person = clientQueue.Dequeue();
             using (MemoryStream memoryStrem = new MemoryStream())
             {
                  var bf = new BinaryFormatter();
                  bf.Serialize(memoryStrem, person);
        
                  byte[] writeData = memoryStrem.ToArray();
        
        
                  byte[] writeDataLen = BitConverter.GetBytes((Int32)writeData.Length);
                  clientStream.Write(writeDataLen, 0, 4);
                  clientStream.Write(writeData, 0, writeData.Length);
             }
        }
    }
    clientStream.Dispose();
    client.Dispose();
