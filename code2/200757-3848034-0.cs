    public static byte[] Compress(byte[] data)
    {
        byte[] result;
        using (MemoryStream baseStream = new MemoryStream())
        {
            using (DeflateStream stream = new DeflateStream(baseStream, CompressionMode.Compress, true))
            {
                stream.Write(data, 0, data.Length);
                stream.Flush();   // <== Added
                result = baseStream.ToArray();
            }
        }
        return result;
    }    
