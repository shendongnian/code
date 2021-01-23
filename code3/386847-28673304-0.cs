        public ArrayList GetAllGroupNames(string ipAddress, string ouPath)
        {
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = GetRootDirectoryEntry(ipAddress, ouPath);
            deSearch.Filter = "(&(objectClass=group))";
            SearchResultCollection results = deSearch.FindAll();
            if (results.Count > 0)
            {
                ArrayList groupNames = new ArrayList();
                foreach (SearchResult group in results)
                {
                    var entry = new DirectoryEntry(group.Path, UserName, Password);
                    string shortName = entry.Name.Substring(3, entry.Name.Length - 3);
                    groupNames.Add(shortName);
                }
                return groupNames;
            }
            else
            {
                return new ArrayList();
            }
        }
