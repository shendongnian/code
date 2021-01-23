    XDocument doc = XDocument.Load("input.xml");
    XElement root = doc.Root;
    
    foreach (XElement e in root.Elements("bar"))
    {
        Console.WriteLine("Elements : " + e.Value);
    }
    foreach (XElement e in root.Descendants("bar"))
    {
        Console.WriteLine("Descendants : " + e.Value);
    }
