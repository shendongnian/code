    List<PlayerBO> source = new List<PlayerBO>();
    DirectoryEntry root = new DirectoryEntry("LDAP://app.shgbit.com");
    DirectoryEntry gbvision = root.Children.Find("OU=UMP");
    DirectorySearcher searcher = new DirectorySearcher(gbvision);
    searcher.Filter = "(objectClass=computer)";
    
    int index = 1;
    foreach (SearchResult each in searcher.FindAll()) 
    {
    	var box = each.GetDirectoryEntry();
    	source.Add(new PlayerBO { Id = index++, Name = box.Properties["name"].Value.ToString(), Description = box.Properties["description"].Value.ToString() });
    }
    
    ListViewAD.ItemsSource = new SelectableSource<PlayerBO>(source);
