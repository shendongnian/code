    DirectoryContext dirCtx = new DirectoryContext(DirectoryContextType.Domain, "domain.lan");
                using (Domain usersDomain = Domain.GetDomain(dirCtx))
                using (DirectorySearcher adsearcher = new DirectorySearcher(usersDomain.GetDirectoryEntry()))
                {
                    adsearcher.Filter = "(&(objectClass=computer) (cn=" + computerHostName + "))";
                    adsearcher.SearchScope = SearchScope.Subtree;
                    adsearcher.PropertiesToLoad.Add("description");
                    SearchResult searchResults = adsearcher.FindOne();
                    if (searchResults.ToString().Length <= 0)
                    {
                        //nothing found
                        Console.Write("Cannot find");
                    }
                    else
                    {
                        Console.Write("Found");
                    }
                }
