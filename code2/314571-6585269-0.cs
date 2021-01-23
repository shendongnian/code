    public static XpsDocument OpenXpsDocument(string url)
    {
        var webClient = new WebClient();
        var data = webClient.DownloadData(url);
        var package = System.IO.Packaging.Package.Open(new MemoryStream(data));
        var xpsDocument = new XpsDocument(package, 
                                          CompressionOption.SuperFast, 
                                          url);
        return xpsDocument;
    }
