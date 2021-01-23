    // other preceeding code    
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
        xmlDoc.AppendChild(xmlDec);
    
        XmlElement elmRoot = xmlDoc.CreateElement("testConfig");
        xmlDoc.AppendChild(elmRoot);
    
        GetConfigTags(xmlDoc, elmRoot, clientToken);
    
        StreamWriter wText = 
            new StreamWriter(CommonCodeClass.configLocation + "EmailConfig.xml");
        xmlDoc.Save(wText);
        wText.Flush();
        wText.Close();
        wText.Dispose();
    }
    // may need a GC.Collect() here
    File.Delete(CommonCodeClass.configLocation + "EmailConfig.xml");
