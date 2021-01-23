    XNamespace test = "test.test";
    XDocument doc = XDocument.Load(file);
    // - or -
    XDocument doc = XDocument.Parse("<SourceMessage ...");
    IEnumerable<string> query = from title in doc.Root.Elements(test + "title")
                                select (string)title.Attribute("type");
    foreach (string item in query)
    {
        Console.WriteLine(item);
    }
