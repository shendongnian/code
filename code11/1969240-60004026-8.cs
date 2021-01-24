    XDocument xml = XDocument.Load("1.xml");
    XNamespace ns = "http://tempuri.org/body";
    
    string[] values = new string[] { "d4p1:FooSegment", "d4p1:BarSegment" };
    var result = xml.Root.DescendantsAndSelf("Segment")
        .Where(r => values.Contains((string)r.Attribute(ns + "type").Value));
    
    foreach (var nodeValue in result)
    {
        if(nodeValue.Attribute(ns + "type").Value.ToString() == "d4p1:FooSegment")
        {
            var fooObject = (FooSegment)new XmlSerializer(typeof(FooSegment)).Deserialize(new StringReader(nodeValue.ToString()));
            Console.WriteLine($"{fooObject.Id[0]}");
        }
        else
        {
            var barObject = (BarSegment)new XmlSerializer(typeof(BarSegment)).Deserialize(new StringReader(nodeValue.ToString()));
            Console.WriteLine($"{barObject.Id[0]}");
        }                
    }
