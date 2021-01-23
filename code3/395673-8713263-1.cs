       Configuration webConfig = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    
            ConfigurationSection webConfigSections = webConfig.GetSection("system.web/httpHandlers");
            if (webConfigSections != null)
            {
             //   PropertyInformationCollection t = webConfigSections.ElementInformation.Properties;
    
                XDocument xmlFile = XDocument.Load(new StringReader(webConfigSections.SectionInformation.GetRawXml()));
                IEnumerable<XElement> query = from c in xmlFile.Descendants("add") select c;
    
                foreach (XElement band in query)
                {
                }
                    
                        
            }
