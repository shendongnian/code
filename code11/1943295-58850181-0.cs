      public static class Gzip {
        public static string Decompress(byte[] data) {
          using (var inStream = new MemoryStream(data))
          using (var outStream = new MemoryStream()) {
            using (var gzStream = new GZipStream(inStream, CompressionMode.Decompress))
              gzStream.CopyTo(outStream);
    
            return Encoding.UTF8.GetString(outStream.ToArray());
          }
        }
      }
