    Dictionary<string,object> dictionary = new Dictionary<string, object>();
    
    dictionary.Add("k1", new List<string> { "L1", "L2", "L3" });
    
    List<Type> knownTypes = new List<Type> { typeof(List<string>) };
    DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string,object>), knownTypes);
    MemoryStream stream = new MemoryStream();
    
    serializer.WriteObject(stream, dictionary);
    
    StreamReader reader = new StreamReader(stream);
    
    stream.Position = 0;
    string xml = reader.ReadToEnd();
