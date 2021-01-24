    using ( FileStream f = new FileStream(filename,
                                          FileMode.Open, FileAccess.Read, FileShare.None,
                                          buffersize) )
    {
      BinaryFormatter bf = new BinaryFormatter(new CoreSurrogateSelector(),
                                               new StreamingContext(StreamingContextStates.All));
      byte[] buf = (byte[])bf.Deserialize(f);
      buf = Decrypt(buf, password);
      if ( compress ) buf = buf.Decompress();
      using ( MemoryStream ms = new MemoryStream() )
      {
        ms.Write(buf, 0, buf.Length);
        ms.Position = 0;
        T obj = (T)bf.Deserialize(ms);
        return obj;
      }
    }
