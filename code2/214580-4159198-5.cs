    public static string Base64Compress(string data, Encoding enc)
    {
      using (var ms = new MemoryStream())
      {
        using (var ds = new DeflateStream(ms, CompressionMode.Compress))
        {
          byte[] b = enc.GetBytes(data);
          ds.Write(b, 0, b.Length);
        }
        return Convert.ToBase64String(ms.ToArray());
      }
    } 
