    using (ClientContext clientContext = GetContextObject())
    {
        string url = "valid url of the file";
        var file = clientContext.Web.GetFileByServerRelativeUrl(url);
    
        using (FileStream fs = new FileStream(file, FileMode.Open))
        {
            File.SaveBinaryDirect(clientContext, file, fs, true);
        }
    }
