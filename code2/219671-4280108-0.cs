    public string request_Resource()
    {
        WebClient wc = new WebClient();
        byte[] data = wc.DownloadData(myuri);
        return Encoding.UTF8.GetString(data);
    }
    
