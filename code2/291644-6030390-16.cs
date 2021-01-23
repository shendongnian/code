    [OperationContract]
    public Stream GetLargeFile()
    {
        return new FileStream(path, FileMode.Open, FileAccess.Read);
    }
    
    [OperationContract]
    public void SendLargeFile(Stream stream)
    {
        // Handle stream here - e.g. save to disk    
        ProcessTheStream(stream);
        // Close the stream when done processing it
        stream.Close();
    }
