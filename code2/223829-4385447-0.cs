    public void UploadText(string text, Encoding encoding, string destUrl)
    {
        SPWeb site = new SPSite(destUrl).OpenWeb();
        site.Files.Add(destUrl, encoding.GetBytes(text));
    }
