    	string distinguishedName = string.Empty;
	string connectionPrefix = "LDAP://" + YourDomain;
	DirectoryEntry entry = new DirectoryEntry(connectionPrefix);
	DirectorySearcher mySearcher = new DirectorySearcher(entry);
	mySearcher.Filter = "(&(objectClass=group)(|(cn=" + objectName + ")(dn=" + objectName + ")))";
	SearchResult result = mySearcher.FindOne();
	//if you can't find the group 1 create it
	//Create group 1
	DirectoryEntry ou = entry.Children.Find(ouPath);
	DirectoryEntry dl = ou.Children.Add("CN=" objectName, "group");
	dl.Properties["sAmAccountName"].Value = objectName;
	dl.Properties["groupType"].Value = ActiveDs.ADS_GROUP_TYPE_ENUM.ADS_GROUP_TYPE_UNIVERSAL_GROUP;
	dl.Properties["mail"].Value = "";
	dl.CommitChanges();
 	//Create  group 2
	DirectoryEntry ou2 = entry.Children.Find(ouPath);
	DirectoryEntry dl2 = ou2.Children.Add("CN=" objectName, "group");
	dl2.Properties["sAmAccountName"].Value = objectName;
	dl2.Properties["groupType"].Value = ActiveDs.ADS_GROUP_TYPE_ENUM.ADS_GROUP_TYPE_UNIVERSAL_GROUP;
	dl2.Properties["mail"].Value = "";
	dl2.CommitChanges();
	// Put group 2 under group 1
	DirectorySearcher Searcher = new DirectorySearcher(entry);
	Searcher.SearchScope = System.DirectoryServices.SearchScope.Subtree;
	Searcher.Filter = "(&(objectClass=group)(|(cn=" ExobjectName + ")(dn=" + ExobjectName + ")))";
	SearchResult AdObj = Searcher.FindOne();
	var dent = AdObj.GetDirectoryEntry();
	dent.Properties["Member"].Add(dl2.Properties["distinguishedName"].Value);
	dent.CommitChanges();
