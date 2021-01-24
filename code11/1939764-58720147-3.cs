    public static void SerializeItem(string fileName)
    {
      var fontInfo = new FontInfo();
     
      using (FileStream fileStream  = File.Create(fileName))
      {
        var formatter = new BinaryFormatter();
        formatter.Serialize(fileStream, fontInfo);
      }
    }
    public static void DeserializeItem(string fileName)
    {     
      using (FileStream fileStream  = File.OpenRead(fileName))
      {
        var formatter = new BinaryFormatter();
        FontInfo fontInfo = (FontInfo) formatter.Deserialize(fileStream);
      }       
    }       
