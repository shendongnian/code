    DirectoryEntry User = YourPreExistingUser();
    
    string managerDN = User.Properties["manager"][0].ToString();
    
    // Browse up the object hierarchy using DirectoryEntry.Parent looking for the
    // domain root (domainDNS) object starting from the existing user.
    DirectoryEntry DomainRoot = User;
    
    do
    {
    	DomainRoot = DomainRoot.Parent;
    }
    while (DomainRoot.SchemaClassName != "domainDNS");
    
    // Use the domain root object we found as the search root for a DirectorySearcher
    // and search for the manager's distinguished name.
    using (DirectorySearcher Search = new DirectorySearcher())
    {
    	Search.SearchRoot = DomainRoot;
    
    	Search.Filter = "(&(distinguishedName=" + managerDN + "))";
    
    	SearchResult Result = Search.FindOne();
    
    	if (Result != null)
    	{
    		DirectoryEntry Manager = Result.GetDirectoryEntry();
    	}
    }
