        XElement container = XElement.Parse(xml);
        XNamespace myPrefix = container.GetNamespaceOfPrefix("myPrefix");
        XElement xmlTree = new XElement(myPrefix + "Item",     
                                new XAttribute("Name", item.Name), 
                                new XAttribute("Mode", item.Mode));
        container.Add(xmlTree);
