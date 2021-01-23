    public static void ReplaceAttributesByNodes(XmlDocument document, XmlNode node)
    {
        if (document == null)
        {
            throw new ArgumentNullException("document");
        }
        if (node == null)
        {
            throw new ArgumentNullException("node");
        }
    
        if (node.HasChildNodes)
        {
            foreach (XmlNode tempNode in node.ChildNodes)
            {
                ReplaceAttributesByNodes(document, tempNode);
            }
        }
    
        if (node.Attributes != null)
        {
            foreach (XmlAttribute attribute in node.Attributes)
            {
                XmlNode element = document.CreateNode(XmlNodeType.Element, attribute.Name, null);
    
                element.InnerText = attribute.InnerText;
    
                node.AppendChild(element);
            }
    
            node.Attributes.RemoveAll();
        }
    }
    //how to use it
    static void Main()
    {
        string eventNodeXPath = "Something/Segments/Segment";//your segments nodes only
    
        XmlDocument document = new XmlDocument();
        document.Load(@"your playlist file full path");//your input playlist file
        XmlNodeList nodes = document.SelectNodes(eventNodeXPath);
    
        if (nodes != null)
        {
            foreach (XmlNode node in nodes)
            {
                ReplaceAttributesByNodes(document, node);
            }
        }
        doc.Save("your output file full path");
    }
