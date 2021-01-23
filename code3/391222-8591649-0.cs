    List<string> strings = new List<string>();
    // Do something to populate the list
    
    BinaryFormatter bf = new BinaryFormatter();
    MemoryStream ms = new MemoryStream();
    
    bf.Serialize(ms, strings);
    ms.Seek(0, SeekOrigin.Begin);
    List<string> copy = (List<string>)bf.Deserialize(ms) ;
    ms.Close(); 
