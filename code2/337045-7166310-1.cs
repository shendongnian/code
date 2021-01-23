    public void DeleteGroup(Model.Asset pAsset) 
    { 
      using(DirectoryEntry ou = new DirectoryEntry("LDAP://" + pResourcePool.Organization.ActiveDirectoryMappings.Single().Identifier)) 
      {
        using(DirectoryEntry group = new DirectoryEntry("LDAP://" + pResourcePool.ActiveDirectoryMappings.Single().Identifier), username, userpwd) 
        { 
        ou.Children.Remove(group); 
        group.CommitChanges(); 
        } 
      }
    } 
