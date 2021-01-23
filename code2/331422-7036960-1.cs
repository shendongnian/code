    private static byte[] GZipUncompress(byte[] data)
    {
        using(var input = new MemoryStream(data))
        using(var gzip = new GZipStream(input, CompressionMode.Decompress))
        using(var output = new MemoryStream())
        {
            gzip.CopyTo(output);
            return output.ToArray();
        }
    }
