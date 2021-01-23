    public static string RegistryKeyLocation = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects";
    [ComRegisterFunction]
    public static void Register(Type type)
    {
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyLocation, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
        if (registryKey == null)
        {
            registryKey = Registry.CurrentUser.CreateSubKey(RegistryKeyLocation);
        }
        string guid = type.GUID.ToString("B");
        RegistryKey bhoKey = registryKey.OpenSubKey(guid, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
        if (bhoKey == null)
        {
            bhoKey = registryKey.CreateSubKey(guid);
        }
        bhoKey.SetValue("IExplorer Extension", 1);
        registryKey.Close();
        bhoKey.Close();
    }
    [ComUnregisterFunction]
    public static void Unregister(Type type)
    {
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyLocation, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
        string guid = type.GUID.ToString("B");
        if (registryKey != null)
        {
            registryKey.DeleteSubKey(guid, false);
        }
    }
