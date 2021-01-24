    XmlDocument doc = new XmlDocument();
    doc.Load(xmlFile);
    XmlNodeList xnl = doc.SelectNodes("/Reply/customer/class");
    foreach (XmlNode node in xnl)
    {
        if (node.ChildNodes[0].InnerText == "CD")
        {
            Console.WriteLine(node.ChildNodes[1].InnerText);
        }
    }
