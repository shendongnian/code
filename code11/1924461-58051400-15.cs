    using ( FileStream f = new FileStream(filename,
                                          FileMode.Create, FileAccess.Write, FileShare.None,
                                          buffersize) )
    {
      var cbf = new BinaryFormatter(new CoreSurrogateSelector(),
                                    new StreamingContext(StreamingContextStates.All));
      using ( MemoryStream ms = new MemoryStream() )
      {
        cbf.Serialize(ms, obj);
        var buf = ms.GetBuffer();
        if ( compress ) buf = buf.Compress();
        cbf.Serialize(f, Encrypt(buf, password));
      }
    }
