    // (replace "part_of_user_name" with some partial user name existing in your AD)
    var userNameContains = "part_of_user_name";
    var identity = WindowsIdentity.GetCurrent().User;
    var allDomains = Forest.GetCurrentForest().Domains.Cast<Domain>();
    var allSearcher = allDomains.Select(domain =>
    {
        var searcher = new DirectorySearcher(new DirectoryEntry("LDAP://" + domain.Name));
        // Apply some filter to focus on only some specfic objects
        searcher.Filter = String.Format("(&(&(objectCategory=person)(objectClass=user)(name=*{0}*)))", userNameContains);
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
    {
        Debug.Print("Name = " + item.Name);
        Debug.Print("Member of:");
        foreach (var groupName in item.GroupName)
        {
            Debug.Print("   " + groupName);
        }
        Debug.Print(String.Empty);
    }
    }
