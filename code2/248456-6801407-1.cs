    string user = Environment.UserDomainName + "\\" + Environment.UserName;
    
    RegistrySecurity rs = new RegistrySecurity();
    
    rs.AddAccessRule(new RegistryAccessRule(user,
        RegistryRights.WriteKey | RegistryRights.ChangePermissions,
        InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny));
    
    RegistryKey rk = null;
    try
    {
      rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\TEST", 
                                       RegistryKeyPermissionCheck.Default, rs);
      rk.SetValue("NAME", "IROSH);
      rk.SetValue("FROM", "SRI LANKA");
    }
