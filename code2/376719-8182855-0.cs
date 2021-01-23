    using (MemoryStream ms = new MemoryStream())
    {
        using (GZipStream gz = new GZipStream(ms, CompressionMode.Compress,true))
        {
            gz.Write(CompressMe, 0, CompressMe.Length);
        }
        return ms.ToArray();
    }
