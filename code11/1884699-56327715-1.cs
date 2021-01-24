    private static byte[] Compress(byte[] data)
    {
        byte[] ret;
        using (var output = new MemoryStream())
        {
          using (var deflateStream = new DeflateStream(output, CompressionLevel.Fastest))
          {
             deflateStream.Write(data, 0, data.Length);
             ret = output.ToArray();
          }
        }
        return ret;
    }
