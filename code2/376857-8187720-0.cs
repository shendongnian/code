    XDocument doc = XDocument.Load("tax.xml");
    XNamespace os = "http://something"; // You haven't included the declaration...
    foreach (XElement cat in doc.Descendants(os + "cat"))
    {
        int catId = (int) cat.Attribute("id");
        string catName = (string) cat.Attribute("name");
        XElement subcat = cat.Element(os + "subcat");
        int subId = (int) subcat.Attribute("id");
        string subName = (string) subcat.Attribute("name");
        foreach (XElement cut in subcat.Elements(os + "cut"))
        {
            string cutUrl = (string) cut.Attribute("cutURL");
            // Use the variables here
        }
    }
