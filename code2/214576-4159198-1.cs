    public Byte[] Compress(Byte[] bytes)
    {
      using (var memoryStream = new MemoryStream())
      {
        using (var deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress))
          deflateStream.Write(bytes, 0, bytes.Length);
        return memoryStream.ToArray();
      }
    }
