    public Stream GetLargeFile()
    {
        var client = /* create proxy here */;
        try
        {
            var response = client.GetLargeFile();
    		
            // All communication is now handled by the stream, 
            // thus we can close the proxy at this point
            client.Close();
    
            return response;
        }
        catch (Exception)
        {
            client.Abort();
            throw;
        }
    }
    public void SendLargeFile(string path)
    {
        var client = /* create proxy here */;
        client.SendLargeFile(new FileStream(path, FileMode.Open, FileAccess.Read));
    }
