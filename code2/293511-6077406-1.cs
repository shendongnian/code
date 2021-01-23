      string domainName = "yourDomain";
            DirectoryEntry entry = new DirectoryEntry("LDAP://DC=" + domainName + ",DC=com");
            DirectorySearcher search = new DirectorySearcher(entry);
            string query = "(&(&(& (mailnickname=*) (| (objectCategory=group) ))))";
            search.Filter = query;
            search.PropertiesToLoad.Add("name");
            SearchResultCollection mySearchResultColl = search.FindAll();
            List<string> groups = new List<string>();
            foreach (SearchResult sr in mySearchResultColl)
            {
                DirectoryEntry de = sr.GetDirectoryEntry();
                groups.Add(de.Properties["Name"].Value.ToString());
            }
