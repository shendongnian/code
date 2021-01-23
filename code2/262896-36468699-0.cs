    // Usage: GetAdGroupsForUser2("domain\user") or GetAdGroupsForUser2("user","domain")
    public static List<string> GetAdGroupsForUser2(string userName, string domainName = null)
    {
        var result = new List<string>();
        if (userName.Contains('\\') || userName.Contains('/'))
        {
            domainName = userName.Split(new char[] { '\\', '/' })[0];
            userName = userName.Split(new char[] { '\\', '/' })[1];
        }
        using (PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, domainName))
            using (UserPrincipal user = UserPrincipal.FindByIdentity(domainContext, userName))
                using (var searcher = new DirectorySearcher(new DirectoryEntry("LDAP://" + domainContext.Name)))
                {
                    searcher.Filter = String.Format("(&(objectCategory=group)(member={0}))", user.DistinguishedName);
                    searcher.SearchScope = SearchScope.Subtree;
                    searcher.PropertiesToLoad.Add("cn");
                    foreach (SearchResult entry in searcher.FindAll())
                        if (entry.Properties.Contains("cn"))
                            result.Add(entry.Properties["cn"][0].ToString());
                }
        return result;
    }
