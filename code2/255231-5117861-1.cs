    string url = "urlToFile";
    using (var client = new WebClient())
    using(var file = File.Create("someFile.ext"))
    {
      var bytes = client.DownloadData(uri);
      file.Write(bytes, 0, bytes.Length);   
    }
