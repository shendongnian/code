    var query = from row in xDocument.Element("Size").Descendants("row")
                select new SizeQuantityXml()
                { 
                    SizeId = (int)row.Attribute("SizeId"),
                    Title = (string)row.Attribute("Title"),
                    Quantity = (int)row.Attribute("Quantity") 
                };
    var sizeQuantityXmlList = query.ToList();
