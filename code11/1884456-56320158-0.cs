    public void CustomSettingXML_WriteValue(string key, string value)
    {
        XDocument doc = XDocument.Load(xmlFile);
        var elements = from x in doc.Descendants("Item") select x;
        foreach (var s in elements)
        {
    		
            if (s.Attribute("Text").Value == key)
            {
                s.Attribute("Value").Value = value; 
                doc.Save(@xmlFile);                    
               break;
            }
        }
    }
