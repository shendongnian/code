        XmlDocument xmlDoc = new XmlDocument();
        XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
        xmlDoc.AppendChild(xmlDec);
        XmlElement elmRoot = xmlDoc.CreateElement("testConfig");
        xmlDoc.AppendChild(elmRoot);
        GetConfigTags(xmlDoc, elmRoot, clientToken);
        using (StreamWriter wText = new StreamWriter(CommonCodeClass.configLocation + "EmailConfig.xml"))
        {
                xmlDoc.Save(wText);
                wText.Flush();
        }
        File.Delete(CommonCodeClass.configLocation + "EmailConfig.xml");
