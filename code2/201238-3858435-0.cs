    DataContractSerializer serializer = new DataContractSerializer(toSers.GetType());
    MemoryStream ms = new MemoryStream();
    serializer.WriteObject(ms, toSer);
    ms.Position = 0;
    
    string serializedContent;
    using(StreamReader sr = new StreamReader(ms))
    {
      serializedContent = sr.ReadToEnd();	
    }
