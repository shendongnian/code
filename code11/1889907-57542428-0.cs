    using (var directoryEntry = new DirectoryEntry(@"LDAP://TestDomain")
	{
		Username = @"TestDomain\TestUser",
		Password = "T@st#1"
	})
	{
		var directorySearcher = new DirectorySearcher(directoryEntry)
		{
			VirtualListView = new DirectoryVirtualListView(0, 9, 1)
		};
        // will give you only users with mail
		var filter = "(&(objectCategory=person)(objectClass=user)(mail=*))";
					
		directorySearcher.Filter = filter;
		directorySearcher.Sort = new SortOption() { PropertyName = "displayname", 
                                                     Direction = SortDirection.Ascending };
	}
	directorySearcher.PropertiesToLoad.Add("displayname");
	directorySearcher.PropertiesToLoad.Add("mail");
	directorySearcher.SearchScope = System.DirectoryServices.SearchScope.Subtree;
	directorySearcher.SizeLimit = 100;
	var results = directorySearcher.FindAll();
	var names = new List<string>();
	foreach (SearchResult r in results)
	{
		// Map the result 
	}
