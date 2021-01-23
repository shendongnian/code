        private void GetConfigSettings() 
        {
            string path = Server.MapPath("Web.config"); 
            string newConnectionString = @"(Your connection string here)"; 
            XmlDocument xDoc = new XmlDocument(); 
            xDoc.Load(path); 
            XmlNodeList nodeList = xDoc.GetElementsByTagName("appSettings"); 
            
            XmlNodeList nodeAppSettings = nodeList[0].ChildNodes; 
            
            XmlAttributeCollection xmlAttCollection = nodeAppSettings[0].Attributes;
            xmlAttCollection[0].InnerXml = txtKey.Text; // for key attribute
            xmlAttCollection[1].InnerXml = newConnectionString; // for value attribute
            
            xDoc.Save(path); // saves the web.config file         
        
        }
