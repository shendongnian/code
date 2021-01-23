    static IEnumerable<string> GetUsernames(string domainName, string groupName) {
      using (var pc = new PrincipalContext(ContextType.Domain, domainName))
      using (var gp = GroupPrincipal.FindByIdentity(pc, groupName))
        return gp == null ? null : new SortedSet<string>(
          gp.GetMembers(true).Select(u => u.SamAccountName));
    }
