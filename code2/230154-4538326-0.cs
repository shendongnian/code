    XDocument doc = //your data
    var q = from node in doc.Descendants()
            where node.Attributes().Count() > 0
            select new {NodeName = node.Name, Attributes = node.Attributes()};
    foreach (var node in q)
    {
        Console.WriteLine( node.NodeName );
        foreach (var attribute in node.Attributes)
        {
            Console.WriteLine(attribute.Name + ":" + attribute.Value);
        }
        Console.WriteLine();
    }
