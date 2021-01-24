    using System.Runtime.Serialization.Formatters.Binary;
    static public long SizeOf(object obj)
    {
      if ( obj == null ) return 0;
      try
      {
        using ( MemoryStream stream = new MemoryStream() )
        {
          new BinaryFormatter().Serialize(stream, obj);
          return stream.Length;
        }
      }
      catch 
      { 
        return -1; 
      }
    }
