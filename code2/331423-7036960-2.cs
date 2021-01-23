    private static byte[] GZipCompress(byte[] data)
    {
        using(var input = new MemoryStream(data))
        using (var output = new MemoryStream())
        {
            using (var gzip = new GZipStream(output, CompressionMode.Compress, true))
            {
                input.CopyTo(gzip); 
            }
            return output.ToArray();
        }
    }
