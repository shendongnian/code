    public string GetXMLValue(string XML, string searchTerm)
    {
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(XML);
      XmlNodeList nodes = doc.SelectNodes("root/key");
      foreach (XmlNode node in nodes)
      {
        XmlAttributeCollection nodeAtt = node.Attributes;
        if(nodeAtt["name"].Value.ToString() == searchTerm)
        {
          XmlDocument childNode = new XmlDocument();
          childNode.LoadXml(node.OuterXml);
          return childNode.SelectSingleNode("key/value").InnerText;
        }
        else
        {
          return "did not match any documents";
        }
      }
    }
