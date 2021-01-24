    WebClient wc = new WebClient();
    using (MemoryStream stream = new MemoryStream(wc.DownloadData("URL")))
    {
        using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
        {
           ...
        }
    }
