    void RunThis()
    {
        using (DirectoryEntry de = new DirectoryEntry())
        {
            de.Path = "LDAP://" + domainName;
            de.Username = username;
            de.Password = password;
            de.AuthenticationType = AuthenticationTypes.Secure;
            
            using (DirectorySearcher deSearch = new DirectorySearcher(de))
            {
                deSearch.SearchScope = SearchScope.Subtree;
                using (SearchResultCollection rescoll = deSearch.FindAll())
                {
                }
            }
        }
    } // end of function 
