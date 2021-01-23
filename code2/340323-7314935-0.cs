    public IEnumerable<KeyValuePair<string, string>> GetAllMembers(string group)
    {
        var domainContext = new PrincipalContext(ContextType.Domain);
        var groupPrincipal = GroupPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, group);
    
        return from m
               in groupPrincipal.Members 
               select new KeyValuePair<string, string>(m.SamAccountName, m.Name);
    }
