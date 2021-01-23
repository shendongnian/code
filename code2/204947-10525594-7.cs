        public static Dictionary<string, string> MapSiteIDs()
        {  
            DirectoryEntry IIS = new DirectoryEntry("IIS://localhost/W3SVC");
            Dictionary<string, string> dictionary = new Dictionary<string, string>(); // key=domain, value=siteId
            foreach (DirectoryEntry entry in IIS.Children)
            {
                if (entry.SchemaClassName.ToLower() == "iiswebserver")
                {
                    string domainName = entry.Properties["ServerComment"].Value.ToString().ToLower();
                    string siteID = entry.Name;
                    dictionary.Add(domainName, siteID);
                }
            }
            return dictionary;
        }
