    // Serialize:
    using (var fs = new FileStream(fileName, FileMode.Create))
    using (var writer = new StreamWriter(fs))
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string s = serializer.Serialize(m_SomeData);                
        writer.Write(s);
    }
    // Deserialize:
    using (var fs = new FileStream(fileName, FileMode.Open))
    using (var reader = new StreamReader(fs))
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        var s = reader.ReadToEnd();
        m_SomeData = serializer.Deserialize<T[]>(s);                
    }
