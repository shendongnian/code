    public static string Decompress(Byte[] bytes)
    {
      using (var uncompressed = new MemoryStream())
      using (var compressed = new MemoryStream(bytes))
      using (var ds = new DeflateStream(compressed, CompressionMode.Decompress))
      {
        ds.CopyTo(uncompressed);
        return Encoding.ASCII.GetString(uncompressed.ToArray());
      }
    }
