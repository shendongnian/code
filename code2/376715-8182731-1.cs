    public static byte[] Compress(byte[] CompressMe)
    {
      MemoryStream ms;
      try 
      {
        ms = new MemoryStream();
        using (GZipStream gz = new GZipStream(ms, CompressionMode.Compress, true))
        {
          ms = null;
          gz.Write(CompressMe, 0, CompressMe.Length);
          ms.Position = 0;
          byte[] Result = new byte[ms.Length];
          ms.Read(Result, 0, (int)ms.Length);
          return Result;
        }
      }
      finally
      {
        if (ms != null)
        {
          ms.Dispose();
        }
      }
