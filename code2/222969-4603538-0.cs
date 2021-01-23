    public bool AuthenticateGroup(string userName, string password, string domain, string group)
        {
    
    
            if (userName == "" || password == "")
            {
                return false;
            }
    
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain, userName, password);
                DirectorySearcher mySearcher = new DirectorySearcher(entry);
                mySearcher.Filter = "(&(objectClass=user)(|(cn=" + userName + ")(sAMAccountName=" + userName + ")))";
                SearchResult result = mySearcher.FindOne();
    
                foreach (string GroupPath in result.Properties["memberOf"])
                {
                    if (GroupPath.Contains(group))
                    {
                        return true;
                    }
                }
            }
            catch (DirectoryServicesCOMException)
            {
            }
            return false;
        }
