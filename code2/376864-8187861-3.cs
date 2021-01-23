    var doc = new XmlDocument();
    var xmlnsManager = new System.Xml.XmlNamespaceManager(doc.NameTable);
    xmlnsManager.AddNamespace("os", "http://bla");
    foreach (XmlNode cat in doc.SelectNodes("/os:cat", xmlnsManager))
    {
        var cat_name = cat.Attributes.GetNamedItem("name").Value;
        var cat_id = cat.Attributes.GetNamedItem("id").Value;
        foreach (XmlNode subcat in catNode.SelectNodes("os:subcat", xmlnsManager))
        {
            var subcat_name = subcat.Attributes.GetNamedItem("name").Value;
            var subcat_id = subcat.Attributes.GetNamedItem("id").Value;
            foreach (XmlNode t in subcat.SelectNodes("os:t", xmlnsManager))
            {
                var t_name = t.Attributes.GetNamedItem("name").Value;
                var t_id = t.Attributes.GetNamedItem("id").Value;
                foreach (XmlNode cut in t.SelectNodes("os:cut"))
                {
                    var cut_name = cut.Attributes.GetNamedItem("name").Value;
                    var cut_id = cut.Attributes.GetNamedItem("id").Value;
                }
            }
        }
    }
