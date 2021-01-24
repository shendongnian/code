    using System.DirectoryServices;
    using System.DirectoryServices.ActiveDirectory;
        public static void FindComputer(string computerHostName)
        {
            DirectoryContext dirCtx = new DirectoryContext(DirectoryContextType.Domain, "domain.lan");
            using (Domain usersDomain = Domain.GetDomain(dirCtx))
            using (DirectorySearcher adsearcher = new DirectorySearcher(usersDomain.GetDirectoryEntry()))
            {
                adsearcher.Filter = "(&(objectClass=computer) (cn=" + computerHostName + "))";
                adsearcher.SearchScope = SearchScope.Subtree;
                adsearcher.PropertiesToLoad.Add("description");
                SearchResultCollection searchResults = adsearcher.FindAll();
                foreach (SearchResult searchResult in searchResults)
                {
                    Console.WriteLine(searchResult.Properties["adspath"][0]);
                }
            }
        }
