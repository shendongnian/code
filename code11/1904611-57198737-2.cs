    if (request == "command")
    {
       //Sending File or bytes to clinet
       using (var streamWrite = new DataWriter(args.Socket.OutputStream)) 
       {
           byte[] inStream = new byte[10025];
           streamWrite.WriteBytes(inStream);
           await streamWrite.StoreAsync();
           await streamWrite.FlushAsync();
           streamWrite.DetachStream();
        }
    }
    
