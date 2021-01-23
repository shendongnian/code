    public ArrayList GetBBGroups(WindowsIdentity identity)
    {
        ArrayList groups = new ArrayList();
        try
        {
            String userName = identity.Name;
            int pos = userName.IndexOf(@"\");
            if (pos > 0) userName = userName.Substring(pos + 1);
            PrincipalContext domain = new PrincipalContext(ContextType.Domain, "riomc.com");
            UserPrincipal user = UserPrincipal.FindByIdentity(domain, IdentityType.SamAccountName, userName);
            DirectoryEntry de = new DirectoryEntry("LDAP://RIOMC.com");
            DirectorySearcher search = new DirectorySearcher(de);
            search.Filter = "(&(objectClass=group)(member=" + user.DistinguishedName + "))";
            search.PropertiesToLoad.Add("samaccountname");
            search.PropertiesToLoad.Add("cn");
            String name;
            SearchResultCollection results = search.FindAll();
            foreach (SearchResult result in results)
            {
                name = (String)result.Properties["samaccountname"][0];
                if (String.IsNullOrEmpty(name))
                {
                    name = (String)result.Properties["cn"][0];
                }
                GetGroupsRecursive(groups, de, name);
            }
        }
        catch
        {
            // return an empty list...
        }
        return groups;
    }
        
    public void GetGroupsRecursive(ArrayList groups, DirectoryEntry de, String dn)
    {
        DirectorySearcher search = new DirectorySearcher(de);
        search.Filter = "(&(objectClass=group)(|(samaccountname=" + dn + ")(cn=" + dn + ")))";
        search.PropertiesToLoad.Add("memberof");
        String group, name;
        SearchResult result = search.FindOne();
        if (result == null) return;
        group = @"RIOMC\" + dn;
        if (!groups.Contains(group))
        {
            groups.Add(group);
        }
        if (result.Properties["memberof"].Count == 0) return;
        int equalsIndex, commaIndex;
        foreach (String dn1 in result.Properties["memberof"])
        {
            equalsIndex = dn1.IndexOf("=", 1);
            if (equalsIndex > 0)
            {
                commaIndex = dn1.IndexOf(",", equalsIndex + 1);
                name = dn1.Substring(equalsIndex + 1, commaIndex - equalsIndex - 1);
                GetGroupsRecursive(groups, de, name);
            }
        }
    }
