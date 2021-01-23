    private void alterNodeValue(string xmlFile, string parent, string node, string newVal)
    {
        string path = System.IO.Path.Combine(dir, xmlFile);
        XDocument xml = XDocument.Load(path );
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
        xml.Save(path); 
    }  
