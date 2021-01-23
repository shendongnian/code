    using (var searcher = new PrincipalSearcher(new UserPrincipal(new PrincipalContext(ContextType.Domain, Environment.UserDomainName))))
	{
		List<UserPrincipal> users = searcher.FindAll().Select(u => (UserPrincipal)u).ToList();
        foreach(var u in users)
            {
                DirectoryEntry d = (DirectoryEntry)e.GetUnderlyingObject();
				Console.WriteLine(d.Properties["GivenName"].Value.ToString() + d.Properties["sn"].Value.ToString());
            }
	}
