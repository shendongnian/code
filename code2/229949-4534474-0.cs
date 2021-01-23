    DataContractJsonSerializer serializer = new DataContractJsonSerializer(MyClass.GetType());
    MemoryStream ms = new MemoryStream();
    
    serializer.WriteObject(ms, MyClass);
    string JsonString =  Encoding.Default.GetString(ms.ToArray());
