    void Main() 
    {
      string myString;  // outside using
    
      using (MemoryStream stream = new MemoryStream ())
      {
         Print(stream);
         myString = Encoding.UTF8.GetString(stream.ToArray());
      }
      ... 
    
    }
