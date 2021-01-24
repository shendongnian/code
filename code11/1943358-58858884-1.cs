    var xDoc = XDocument.Parse(xml);
    var elementCollection = xDoc.Root.Elements("Element1")
    						  .OrderBy(x=> int.Parse(x.Element("id").Value)).ToList();
    	
    foreach(var element in elementCollection.Where(x=>x.Descendants().Any(c=>c.Name.LocalName.StartsWith("ElementInside"))).ToArray())
    {
        var innerElements = element.Descendants()
    						 .Where(x=>!x.Name.LocalName.Equals("id"))
    						 .GroupBy(x=>x.Name.LocalName)
    						 .Select(x=>x.ToList().OrderBy(c=>c.Element("id") == null ? "0" : c.Element("id").Value))
    						 .SelectMany(x=>x).ToList();
    	innerElements.Insert(0,element.Element("id"));
    	element.ReplaceAll(innerElements);
    }
    var result = new XElement("AFDatabase", elementCollection);
