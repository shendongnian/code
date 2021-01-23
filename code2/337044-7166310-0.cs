    public void DeleteGroup(Model.Asset pAsset) 
    { 
      string username = GetUserName();
      string userpwd  = GetUserPwd();
      using(DirectoryEntry ou = new DirectoryEntry(pResourcePool.Organization.ActiveDirectoryMappings.Single().Identifier, username, userpwd)) 
      {
        using(DirectoryEntry group = new DirectoryEntry("LDAP://" + pResourcePool.ActiveDirectoryMappings.Single().Identifier), username, userpwd) 
        { 
        ou.Children.Remove(group); 
        group.CommitChanges(); 
        } 
      }
    } 
