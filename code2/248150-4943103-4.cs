    XmlDocument doc = new XmlDocument();
    
    XmlNode tagNode = doc.CreateNode(XmlNodeType.Element, "TAG", null);
    doc.AppendChild(tagNode);
    
    XmlNode subTagNode1 = doc.CreateNode(XmlNodeType.Element, "SUBTAG", null);
    tagNode.AppendChild(subTagNode1);
    XmlText subTagNode1Value = doc.CreateTextNode("value");
    subTagNode1.AppendChild(subTagNode1Value);
    
      
    XmlNode subTagNode2 = doc.CreateNode(XmlNodeType.Element, "SUBTAG", null);
    tagNode.AppendChild(subTagNode2);
    XmlAttribute subTagNode2Attribute = doc.CreateAttribute("attr");
    subTagNode2Attribute.Value = "hello";
    
    subTagNode2.Attributes.SetNamedItem(subTagNode2Attribute);
    XmlText subTagNode2Value = doc.CreateTextNode("world");
    subTagNode2.AppendChild(subTagNode2Value);
    
    string xmlString = null;
    using(StringWriter wr = new StringWriter())
    {
    	doc.Save(wr);
    	xmlString = wr.ToString();
    }
