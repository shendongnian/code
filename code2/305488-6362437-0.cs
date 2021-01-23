    void RunThis()
    {
            using(DirectoryEntry de = new DirectoryEntry())
            {
              de.Path = "LDAP://" + domainName;
              de.Username = username;
              de.Password = password;
              de.AuthenticationType = AuthenticationTypes.Secure;
    
              DirectorySearcher deSearch = new DirectorySearcher(de);
              //Skipping properties to load
              try
              {
                deSearch.SearchScope = SearchScope.Subtree;
                SearchResultCollection rescoll = deSearch.FindAll();
                deSearch.Dispose();
                rescoll.Dispose();
              }
              catch (Exception obj)
              {
                System.Console.WriteLine("Exception in getting results. {0}",obj.Message);
              }
            }
    }
