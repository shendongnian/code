    string ReadRegOwner(string dir)
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(dir, false);
        RegistrySecurity rs = key.GetAccessControl();
        IdentityReference owner = rs.GetOwner(typeof(System.Security.Principal.NTAccount));
    
        return owner.ToString();
    }
