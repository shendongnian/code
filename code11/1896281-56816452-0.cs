    private void BindCountry()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("~//App_Data//countries.xml"));
    
        foreach (XmlNode node in doc.SelectNodes("//country"))
        {
            ddlcountry.Items.Add(new ListItem(node.InnerText, node.Attributes["code"].InnerText));
        }
    }
