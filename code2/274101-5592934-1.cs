    XmlDocument xdoc = new XmlDocument();
    xdoc.LoadXml(myXml);
    
    XmlNodeList xnl = xdoc.SelectNodes("NameValueList/NameValue");
    foreach (XmlNode xn in xnl)
    {
        string id = xn.Attributes["Id"].Value;
        string apply = xn.SelectSingleNode("Apply").InnerText;
        string value = xn.SelectSingleNode("Value").InnerText;
    }
