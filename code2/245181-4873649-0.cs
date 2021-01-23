    class MultiTextWriter : TextWriter
    {
      TextWriter[] Writers {get;set;}
    
      override void Write(string foo)
      {
        foreach (var w in Writers) w.Write(foo);
      }
    }
