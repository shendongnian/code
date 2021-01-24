    FatherElement e = new FatherElement();
    e.FatherClass = "Some Element";
    // Here we choose our element in our choice. It'll be boxed into an object.
    e.Item = new FatherElementCompleteFather()
    {
        FatherLocation = "loc",
        FatherType = "type",
        FatherTypeDescription = "desc"
    };
    string filePath = @"C:\Temp\test.xml";
    XmlSerializer x = new XmlSerializer(e.GetType());
    using (var sw = new StreamWriter(filePath))
        x.Serialize(sw, e);
