    string userPath = string.Format("WinNT://{0}/{1},user", domain, user);
    string groupPath = string.Format("WinNT://{0}/{1},group", Environment.MachineName, group);
    using (DirectoryEntry group = new DirectoryEntry(groupPath))
    {
    	group.Invoke("Add", userPath);
    	group.CommitChanges();
    }
    
