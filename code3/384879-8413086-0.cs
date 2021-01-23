    IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 5656);
    Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
    listener.Bind(ipEnd);
    listener.Listen(100);
    
    Console.WriteLine("Waiting for a connection...");
    Socket handler = listener.Accept();
                
    while (true)
    {
        // 1024 * 25.000 = 25mb max that can be received at once with this program.
        byte[] clientData = new byte[1024 * 25000];
        string receivedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\";
    
        int bytesRec = handler.Receive(clientData);
        int fileNameLen = BitConverter.ToInt32(clientData, 0);
        string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);
    
        BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Append)); ;
        bWrite.Write(clientData, 4 + fileNameLen, bytesRec - 4 - fileNameLen);
        bWrite.Close();
    }
    
    //dont forget to close handler at server shutdown
    //handler.Shutdown(SocketShutdown.Both);
    //handler.Close();
