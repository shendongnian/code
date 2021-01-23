    public static List<string> GetComputerUsers()
    {
    	List<string> users = new List<string>();
    	var path =
    		string.Format("WinNT://{0},computer", Environment.MachineName);
    
    	using (var computerEntry = new DirectoryEntry(path))
    		foreach (DirectoryEntry childEntry in computerEntry.Children)
    			if (childEntry.SchemaClassName == "User")
    				users.Add(childEntry.Name);
    
    	return users;
    }
