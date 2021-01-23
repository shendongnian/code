      var compress = new Func<byte[], byte[]>( a => {
            using (var ms = new System.IO.MemoryStream())
            {
                using (var compressor =
                       new Ionic.Zlib.ZlibStream( ms, 
                                                  CompressionMode.Compress,
                                                  CompressionLevel.Default )) 
                {
                    compressor.Write(a,0,a.Length);
                }
                return ms.ToArray();
            }
        });
      var original = new byte[] { .... };
      var compressed = compress(original);
  
