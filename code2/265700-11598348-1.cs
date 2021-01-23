    using(RegistryKey rk =   
        Registry.LocalMachine.OpenSubKey(@"SOFTWARE\paci_1\identity\ASPNET_SETREG") )
    {
        string gname = Environment.UserDomainName + @"\" + Environment.UserName;   
        RegistrySecurity rs = new RegistrySecurity();
        rs.AddAccessRule(new RegistryAccessRule(gname, RegistryRights.ReadKey, AccessControlType.Allow));
        rk.SetAccessControl(rs);
    }
