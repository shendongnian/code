    XNamespace yns = "http://www.yworks.com/xml/graphml";
    Dictionary<string, List<string>> keys = new Dictionary<string, List<string>>();
    foreach (var node in doc.Descendants(ns + "node"))
    {
        keys[node.Attribute("id").Value] = new List<string>();
        foreach (var nodeLabel in node.Descendants(yns + "NodeLabel"))
        {
            keys[node.Attribute("id").Value].Add(nodeLabel.Value);
        }
    }
    
    foreach (var entry in keys)
    {
        Console.WriteLine($"Key: {entry.Key}");
        foreach (var basemodel in entry.Value)
        {
            Console.WriteLine($"->basemodel: {basemodel}");
        }
    }
