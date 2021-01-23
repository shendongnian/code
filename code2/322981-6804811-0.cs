    XDocument doc = XDocument.Load("test.xml");
    foreach (var delimiter in doc.Descendants("Delimiters").Elements())
        Console.WriteLine(string.Format("{0} : {1}", delimiter.Name, delimiter.Value));
    foreach (var type in doc.Descendants("SourceType").Elements())
        Console.WriteLine(string.Format("{0} : {1}", type.Name, type.Value));
