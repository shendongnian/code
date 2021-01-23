        var xml = XDocument.Parse("<items><item item=\"A\" position=\"0\"><itemvalue>10</itemvalue></item><item item=\"A\" position=\"1\"><itemvalue>20</itemvalue>"
            + "</item><item item=\"A\" position=\"2\"><itemvalue>30</itemvalue></item><item item=\"B\" position=\"0\"><itemvalue>10</itemvalue>"
            + "</item><item item=\"B\" position=\"1\"><itemvalue>20</itemvalue></item><item item=\"B\" position=\"2\"><itemvalue>30</itemvalue>"
            + "</item></items>").Root;
        var keys = xml.Elements().GroupBy(x => x.Attribute("item").Value).Select(x => x.Key);
        var flattened = new XDocument();
        flattened.Add(new XElement("flattened"));
        foreach (var key in keys)
        {
            var elements = xml.Elements().Where(x => x.Attribute("item").Value == key);
            var tempElement = new XElement("Item");
            tempElement.Add(new XAttribute("Item", elements.First().Attribute("item").Value));
            tempElement.Add(new XAttribute("Column1", elements.First().Element("itemvalue").Value));
            tempElement.Add(new XAttribute("Column2", elements.ElementAt(1).Element("itemvalue").Value));
            tempElement.Add(new XAttribute("Column3", elements.Last().Element("itemvalue").Value));
            
            flattened.Root.Add(tempElement);
        }
        Console.WriteLine(flattened.ToString());
        Console.ReadLine();
