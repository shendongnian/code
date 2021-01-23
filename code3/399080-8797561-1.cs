    static void Main(string[] args)
    {
        var xml = XDocument.Parse("<items><item item=\"A\" position=\"0\"><itemvalue>10</itemvalue></item><item item=\"A\" position=\"1\"><itemvalue>20</itemvalue>"
            + "</item><item item=\"A\" position=\"2\"><itemvalue>30</itemvalue></item><item item=\"B\" position=\"0\"><itemvalue>10</itemvalue>"
            + "</item><item item=\"B\" position=\"1\"><itemvalue>20</itemvalue></item><item item=\"B\" position=\"2\"><itemvalue>30</itemvalue>"
            + "</item></items>").Root;
    
        var keys = xml.Elements()
                      .GroupBy(x => x.Attribute("item").Value)
                      .Select(x => x.Key);
    
        var flattened = new XDocument();
    
        flattened.Add(new XElement("flattened"));
    
        foreach (var item in keys)
        {
            var elements = xml.Elements().Where(x => x.Attribute("item").Value == item);
            flattened.Root.Add(new XElement("Item", new XAttribute("Item", elements.First().Attribute("item").Value)
                , new XAttribute("Column1", elements.First().Element("itemvalue").Value)
                , new XAttribute("Column2", elements.ElementAt(1).Element("itemvalue").Value)
                , new XAttribute("Column3", elements.Last().Element("itemvalue").Value)));
        }
    
        Console.WriteLine(flattened.ToString());
    
        Console.ReadLine();
    }
