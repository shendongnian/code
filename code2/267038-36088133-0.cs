    private const string MyRegistryKeyPath = "Software\\My Company\\My App";
    
    private static RegistryKey OpenMyAppRegistryKey(bool requireWriteAccess = false)
    {
        using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
        {
            return requireWriteAccess
                ? baseKey.CreateSubKey(MyRegistryKeyPath, RegistryKeyPermissionCheck.ReadWriteSubTree)
                : baseKey.OpenSubKey(MyRegistryKeyPath, RegistryKeyPermissionCheck.ReadSubTree);
        }
    }
