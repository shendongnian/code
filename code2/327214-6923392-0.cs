    using (MemoryStream stream = new MemoryStream())
    {
      var enc = new UTF8Encoding(false);
      using (XmlTextWriter writer = new XmlTextWriter(stream,enc))
      {
        serializer.Serialize(writer, myClass);        
      }
      string xml = Encoding.UTF8.GetString(
          stream.GetBuffer(), 0, (int)stream.Length);
    }
