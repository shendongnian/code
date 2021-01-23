    DirectoryEntry directoryEntry = new DirectoryEntry(
          config.DirectoryConnectionString, 
          config.ActiveDirectoryUserName, 
          config.GetPassword(), 
          AuthenticationTypes.Secure);
    DirectorySearcher ds = new DirectorySearcher(directoryEntry);
            
    ds.PropertiesToLoad.Add("cn");
    ds.PropertiesToLoad.Add("sAMAccountName");
    ds.PropertiesToLoad.Add("mail");
    ds.PropertiesToLoad.Add("displayName");
    ds.Filter = "(objectClass=user)";
    foreach (SearchResult result in ds.FindAll())
    {
        string displayName = String.Empty;
        DirectoryEntry entry = result.GetDirectoryEntry();
        if (entry.Properties.Contains("displayName"))
                if (entry.Properties["displayName"].Count > 0)
                    displayName  = entry.Properties["displayName"][0].ToString();
    }
