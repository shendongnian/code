    var list = new List<List<int>>();
    using (var writer = new BinaryWriter(new FileStream("FileName", FileMode.Create)))
    {
       foreach (var inner in list)
       {
          writer.Write(inner.Count);
          foreach (var item in inner)
             writer.Write(item);
       }
    }
    
    var results = new List<List<int>>();
    
    using (var reader = new BinaryReader(new FileStream("FileName", FileMode.Open)))
    {
       while(reader.BaseStream.Position < reader.BaseStream.Length)
       {
          var size = reader.ReadInt32();
    
          var inner = new List<int>(size);
          results.Add(inner);
          for (int i = 0; i < size; i++)
             inner.Add(reader.ReadInt32());
       }
    }
