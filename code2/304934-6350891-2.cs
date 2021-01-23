    public static byte[] Decompress(byte[] bSource)
    {
        using (var inStream = new MemoryStream(bSource))
        using (var gzip = new GZipStream(inStream, CompressionMode.Decompress))
        using (var outStream = new MemoryStream())
        {
            gzip.CopyTo(outStream);
            return outStream.ToArray();
        }
    }
