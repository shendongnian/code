        XmlDocument doc = new XmlDocument();
        XmlReaderSettings xrs = new XmlReaderSettings()
        {
            ValidationType = ValidationType.Schema
        };
        xrs.Schemas.Add(null, "schema.xsd");
        using (XmlReader xr = XmlReader.Create("input.xml", xrs))
        {
            doc.Load(xr);
        }
        string isbn = "ISBN9789127121867";
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("bs", "http://litemedia.se/BookStore.xsd");
        string path = string.Format("id(id('{0}')/bs:author-ref/@id)", isbn);
        foreach (XmlElement author in doc.XPathSelectNodes(path, nsmgr))
        {
            Console.WriteLine(author.OuterXml);
        }
