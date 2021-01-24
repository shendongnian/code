    System.IO.Compression.GZipStream gzipStream;
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
        gzipStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
    
        using (StreamReader sr = new StreamReader(gzipStream))
        {
            Console.Write(sr.ReadToEnd());
        }
    }
