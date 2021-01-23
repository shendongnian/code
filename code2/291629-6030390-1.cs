    private Stream GetLargeFile()
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
