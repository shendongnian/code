        public static Dictionary<string, string> MapSiteIDs()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(); // key=domain, value=siteId
            foreach (DirectoryEntry entry in IIS.Children)
            {
                if (entry.SchemaClassName.ToLower() == "iiswebserver")
                {
                    string domainName = entry.Properties["ServerComment"].Value.ToString().ToLower();
                    dictionary.Add(domainName, entry.Name);
                }
            }
            return dictionary;
        }
