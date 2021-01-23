    var result = new XElement("root");
    result.Add(new XElement("first", "hello"));
    result.Add(new XElement("second", "world"));
    Console.WriteLine(result.Element("first").Value); 
    Console.WriteLine(result.Element("second").Value);
    foreach (var element in result.Elements())
        Console.WriteLine(element.Name + ": " + element.Value);
