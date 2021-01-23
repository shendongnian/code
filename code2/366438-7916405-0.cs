    public static DataTable GetListOfActiveUsers(string domainName)
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://DC=" + domainName + ",DC=com");
            DirectorySearcher search = new DirectorySearcher(entry);
            string query = "(&(objectCategory=person)(objectClass=user)(!(userAccountControl:1.2.840.113556.1.4.803:=2))(&(mail=*)))";
            search.Filter = query;
            search.PropertiesToLoad.Add("name");
            search.PropertiesToLoad.Add("mail");
            SearchResultCollection mySearchResultColl = search.FindAll();
            DataTable results = new DataTable();
            results.Columns.Add("name");
            results.Columns.Add("mail");
            foreach (SearchResult sr in mySearchResultColl)
            {
                DataRow dr = results.NewRow();
                DirectoryEntry de = sr.GetDirectoryEntry();
                dr["name"] = de.Properties["Name"].Value;
                dr["mail"] = de.Properties["mail"].Value;
                results.Rows.Add(dr);
                de.Close();
            }
            return results;
        }
    }
