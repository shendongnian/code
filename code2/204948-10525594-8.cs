        string GetSiteID(string domain)
        {
            string siteId = string.Empty;
            DirectoryEntry iis = new DirectoryEntry("IIS://localhost/W3SVC");
            foreach (DirectoryEntry entry in iis.Children)
                if (entry.SchemaClassName.ToLower() == "iiswebserver")
                    if (entry.Properties["ServerComment"].Value.ToString().ToLower() == domain.ToLower())
                        siteId = entry.Name;
            if (string.IsNullOrEmpty(siteId))
                throw new Exception("Could not find site '" + domain + "'");
            return siteId;
        }
