    XDocument doc = XDocument.Load("tax.xml");
    XNamespace os = "http://something"; // You haven't included the declaration...
    foreach (XElement cat in doc.Descendants(os + "cat"))
    {
        int catId = (int) cat.Attribute("id");
        string catName = (string) cat.Attribute("name");
        foreach (XElement subcat in cat.Elements(os + "subcat"))
        {
            int subId = (int) subcat.Attribute("id");
            string subName = (string) subcat.Attribute("name");
            foreach (XElement t in subcat.Elements(os + "t"))
            {
                int tId = (int) t.Attribute("id");
                string tName = (string) t.Attribute("name");
                foreach (XElement cut in t.Elements(os + "cut"))
                {
                    string cutId = (int) cut.Attribute("id");
                    string cutName = (string) cut.Attribute("name");
                    string cutUrl = (string) cut.Attribute("cutURL");
                    // Use the variables here
                }
            }
        }
    }
