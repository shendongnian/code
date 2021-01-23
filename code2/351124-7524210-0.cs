    /* Retreiving object from SID 
      */ 
    string SidLDAPURLForm = "LDAP://WM2008R2ENT:389/<SID={0}>"; 
    System.Security.Principal.SecurityIdentifier sidToFind = new System.Security.Principal.SecurityIdentifier("S-1-5-21-3115856885-816991240-3296679909-1106"); 
     
    DirectoryEntry userEntry = new DirectoryEntry(string.Format(SidLDAPURLForm, sidToFind.Value)); 
    string name = userEntry.Properties["userPrincipalName"].Value.ToString(); 
