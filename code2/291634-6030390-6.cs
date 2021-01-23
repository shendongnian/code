    [OperationContract]
    public Stream GetLargeFile()
    {
        return new FileStream(path, FileMode.Open, FileAccess.Read);
    }
    
    [OperationContract]
    public void SendLargeFile(Stream stream)
    {
        // Handle stream here - e.g. save to disk    
        ProcessStream(stream);
        // Close stream (at the server, not at the client)
        stream.Close();
    }
