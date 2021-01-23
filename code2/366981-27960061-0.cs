    Microsoft.Win32.RegistryKey key;
    key = Microsoft.Win32.Registry.LocalMachine;
    RegistrySecurity rs = new RegistrySecurity();
    rs = key.GetAccessControl();
    string currentUserStr = Environment.UserDomainName + "\\" + Environment.UserName;
    rs.AddAccessRule(new RegistryAccessRule(currentUserStr, RegistryRights.WriteKey |  RegistryRights.ReadKey | RegistryRights.Delete | RegistryRights.FullControl, AccessControlType.Allow));
