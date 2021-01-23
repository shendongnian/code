    static void Main(string[] args)
    {
      using (var file = MemoryMappedFile.CreateFromFile(@"d:\temp\temp.xml", FileMode.Open,  "MyMemMapFile"))
      {
         using (MemoryMappedViewStream stream = file.CreateViewStream())
        {
            Read(stream);
        }
       }
    }
    static void Read(Stream stream)
    {
      using (XmlReader reader = XmlReader.Create(new StreamReader(stream, Encoding.UTF8)))
      {
         reader.MoveToContent();
        while (reader.Read())
        {
        }
     }
    }
