    var doc = XDocument.Load(/* ... */);
    
    foreach (var g in doc.Descendants("contactGrp"))
    {
    	var customers = g.Elements("customer").ToList();
    	customers.Remove();
    	g.Add(customers.OrderBy(c => c.Attribute("name").Value));
    }
