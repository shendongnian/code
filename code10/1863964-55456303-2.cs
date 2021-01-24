            public bool AuthenticateGroup(string userName, string password, string domain, string group)
        {
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain, userName, password);
                DirectorySearcher mySearcher = new DirectorySearcher(entry)
                {
                    Filter = "(&(objectClass=user)(|(cn=" + userName + ")(sAMAccountName=" + userName + ")))"
                };
                SearchResult result = mySearcher.FindOne();
                foreach (string GroupPath in result.Properties["memberOf"])
                {
                    if (GroupPath.Contains(group))
                    {
                        return true;
                    }
                }
            }
            catch (DirectoryServicesCOMException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
