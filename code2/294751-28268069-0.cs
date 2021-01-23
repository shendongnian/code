    public static void ShowSecurity(RegistryKey regKeyRoot, string user) 
    {
    
    regKeyRoot.OpenSubKey("", RegistryKeyPermissionCheck.ReadWriteSubTree,
                        RegistryRights.ChangePermissions);
    
    RegistrySecurity security = regKeyRoot.GetAccessControl(AccessControlSections.All);
    
    security.SetGroup( new NTAccount("Administrators") );
    security.SetOwner( new NTAccount("ali") ); //Your account name
    security.SetAccessRuleProtection(true, false);
    regKeyRoot.SetAccessControl(security);
    
    //---------
    
      foreach (RegistryAccessRule ar in security.GetAccessRules(true, true, typeof(NTAccount))) 
      {
        if (ar.IdentityReference.Value.Contains(User) && ar.AccessControlType ==  AccessControlType.Deny )
           security.RemoveAccessRuleSpecific(ar);
      }
    
    regKeyRoot.SetAccessControl(security);
     
      
    }
