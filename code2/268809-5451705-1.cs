    private void alterNodeValue(string xmlFile, string parent, string node, string newVal)
    {
        XDocument xml = XDocument.Load(this.dir + xmlFile);
        XElement parent = xml.Element(parent).Element(node);
        if (parent != null)
        {
            XElement node = parent.Element(parent);
            if (node != null)
            {
                node.Value = newVal;
            }
            else
            {
                // no node
            }
        }
        else
        {
            // no parent
        }    
        xml.Save(dir + xmlFile); 
    }  
