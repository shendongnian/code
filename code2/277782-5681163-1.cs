    private static string GetKeyValue(string keyname)
    {
        string rtnValue = String.Empty;
        try
        {
            ConfigurationSectionGroup sectionGroup = config.GetSectionGroup("logonurls");
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(sectionGroup);
            foreach (System.Xml.XmlNode node in doc.ChildNodes)    
            {    
                // I want to loop through all the settings element of the section
                Console.WriteLine(node.Value);
            }
        }
        catch (Exception e)
        {
        }
        return rtnValue; 
    }
