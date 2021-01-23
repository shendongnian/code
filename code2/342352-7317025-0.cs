      public IList<string> GetGroupsByUser(string ldapConnectionString, string username)
            {
                IList<string> groupList = new List<string>();
     
                var identity = WindowsIdentity.GetCurrent().User;
                var allDomains = Forest.GetCurrentForest().Domains.Cast<Domain>();
     
                var allSearcher = allDomains.Select(domain =>
                {
                    var searcher = new DirectorySearcher(new DirectoryEntry(ldapConnectionString));
     
                    // Apply some filter to focus on only some specfic objects
                    searcher.Filter = String.Format("(&(&(objectCategory=person)(objectClass=user)(name=*{0}*)))", username);
                    return searcher;
                });
     
                var directoryEntriesFound = allSearcher
                    .SelectMany(searcher => searcher.FindAll()
                        .Cast<SearchResult>()
                        .Select(result => result.GetDirectoryEntry()));
     
                var memberOf = directoryEntriesFound.Select(entry =>
                {
                    using (entry)
                    {
                        return new
                        {
                            Name = entry.Name,
                            GroupName = ((object[])entry.Properties["MemberOf"].Value).Select(obj => obj.ToString())
                        };
                    }
                });
     
                foreach (var item in memberOf)
                    foreach (var groupName in item.GroupName)
                        groupList.Add(groupName);
     
                return groupList;
            }
