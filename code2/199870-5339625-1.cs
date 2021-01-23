    public void CreateUserAccount(string login , string password , string fullName, bool isAdmin)
    {
    	try
    	{
    		DirectoryEntry dirEntry = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
    		DirectoryEntries entries = dirEntry.Children;
    		DirectoryEntry newUser  = entries.Add (login, "user");
    		newUser.Properties["FullName"].Add(fullName);
    		newUser.Invoke("SetPassword", password);
    		newUser.CommitChanges();
    		
    		// Remove the if condition along with the else to create user account in "user" group.
    		DirectoryEntry grp;
    		if (isAdmin)
    		{
    			grp = dirEntry.Children.Find("Administrators", "group");
    			if (grp != null) {grp.Invoke("Add", new object[] {newUser.Path.ToString()});}
    		}
    		else
    		{
    			grp = dirEntry.Children.Find("Guests", "group");
    			if (grp != null) {grp.Invoke("Add", new object[] {newUser.Path.ToString()});}
    		}
    			
    	}
    	catch (Exception ex)
    	{
    			MessageBox.Show(ex.ToString());
    	}
    }
