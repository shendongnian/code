    private IEnumerable<string> GetGroupsForDistinguishedName(DirectoryEntry domainDirectoryEntry, string distinguishedName)
    {
        var groups = new List<string>();
        if (!string.IsNullOrEmpty(distinguishedName))
        {
            var getGroupsFilterForDn = $"(member:1.2.840.113556.1.4.1941:={distinguishedName})";
            using (var dirSearch = CreateDirectorySearcher(domainDirectoryEntry, getGroupsFilterForDn))
            {
                dirSearch.PropertiesToLoad.Add("name");
                using (var results = dirSearch.FindAll())
                {
                    foreach (SearchResult result in results)
                    {
                        if (result.Properties.Contains("name"))
                            groups.Add((string)result.Properties["name"][0]);
                    }
                }
            }
        }
        return groups;
    }
