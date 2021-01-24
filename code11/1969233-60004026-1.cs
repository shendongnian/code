    XDocument xml = XDocument.Load("1.xml");
    XNamespace ns = "http://tempuri.org/body";
    
    string[] filterList = new string[] { "d4p1:FooSegment", "d4p1:BarSegment" };
    var result = xml.Root.DescendantsAndSelf("Segment")
        .Where(r => filterList.Contains((string)r.Attribute(ns + "type").Value));
    
    foreach (var nodeValue in result)
    {
        Console.WriteLine($"{nodeValue.Value}");
    }
