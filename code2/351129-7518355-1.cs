    string source;
    var response = req.GetResponse();
            
    var stream = response.GetResponseStream();
    try
    {
        if (response.Headers.AllKeys.Contains("Content-Encoding")
            && response.Headers["Content-Encoding"].Contains("gzip"))
        {
            stream = new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Decompress);
        }
        using (StreamReader reader = new StreamReader(stream))
        {
            source = reader.ReadToEnd();
        }
    }
    finally
    {
        if (stream != null)
            stream.Dispose();
    }
