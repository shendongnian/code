    XmlNodeList xNList = xDOC.SelectNodes("//" + XMLElementname);
    foreach (XmlNode xNode in xNList)
    {
        if (xNode.ChildNodes.Count == 1 && 
            xNode.FirstChild.GetType().ToString() == "System.Xml.XmlText")
        {
            XMLElements.Add(xNode.FirstChild.Value);
        }
        else
        {
            XMLElements.Add("This is not a Leaf node");
        }
    }
