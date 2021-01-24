            public bool IsAuthenticated(string username, string passwd, string domain)
        {
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain, username, passwd, AuthenticationTypes.Secure);
                DirectorySearcher search = new DirectorySearcher(entry)
                {
                    Filter = "(objectClass=user)",
                    SearchScope = SearchScope.Subtree
                };
                SearchResult result = search.FindOne();
                return (result != null);
            }
            catch (Exception ex)
            {
                throw new Exception("Authentication Error.\n" + ex.Message);
            }
