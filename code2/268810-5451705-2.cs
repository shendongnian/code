    private void alterNodeValue(string xmlFile, string parent, string node, string newVal)
    {
        XDocument xml = XDocument.Load(this.dir + xmlFile);
        XElement parent = xml.Element(parent).Element(node);
        if (parent  != null)
        {
            parent.Value = newVal;
        }
        else
        {
            xml.Element(parent).Add(new XElement(node, newVal)); 
        }    
        xml.Save(dir + xmlFile); 
    }  
