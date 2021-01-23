    var set = new HashSet<string>();
    set.Add("hello");
    set.Add("world");
    
    var xs = new XmlSerializer(typeof(HashSet<string>));
    string xml;
    using (var writer = new StringWriter())
    {
        xs.Serialize(writer, set);
        xml = writer.ToString();
        Console.WriteLine(xml);
    }
    using (var reader = new StringReader(xml))
    {
        var set2 = (HashSet<string>)xs.Deserialize(reader);
        foreach(string s in set2) Console.WriteLine(s);
    }
