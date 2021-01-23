    using ( Stream     compressed = File.OpenWrite( @"c:\foobar.zlib" ) )
    using ( ZlibStream zlib       = new ZlibStream( compressed , CompressionMode.Compress ) )
    {
      byte[] buf ;
      while ( null != (buf=ReadSomeDataToCompress()) )
      {
        zlib.Write(buf,0,buf.Length) ;
      }
    }
