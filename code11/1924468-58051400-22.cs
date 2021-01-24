    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    static public string Compress(this string text)
    {
      if ( text.IsNullOrEmpty() ) return text;
      return Convert.ToBase64String(Encoding.Default.GetBytes(text).Compress());
    }
    static public byte[] Compress(this byte[] buffer)
    {
      using ( MemoryStream ms = new MemoryStream() )
      {
        using ( GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true) )
          zip.Write(buffer, 0, buffer.Length);
        ms.Position = 0;
        byte[] compressed = new byte[ms.Length];
        ms.Read(compressed, 0, compressed.Length);
        byte[] gzBuffer = new byte[compressed.Length + 4];
        System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
        System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
        return gzBuffer;
      }
    }
    static public string Decompress(this string text)
    {
      return Encoding.Default.GetString(Convert.FromBase64String(text).Decompress());
    }
    static public byte[] Decompress(this byte[] gzBuffer)
    {
      using ( MemoryStream ms = new MemoryStream() )
      {
        int msgLength = BitConverter.ToInt32(gzBuffer, 0);
        ms.Write(gzBuffer, 4, gzBuffer.Length - 4);
        byte[] buffer = new byte[msgLength];
        ms.Position = 0;
        using ( GZipStream zip = new GZipStream(ms, CompressionMode.Decompress) )
          zip.Read(buffer, 0, buffer.Length);
        return buffer;
      }
    }
