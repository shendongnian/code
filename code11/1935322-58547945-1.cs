    public static RegistryHive GetRegistryHive(this RegistryKey key)
    {
        if (key == null)
    	{
    		throw new System.ArgumentNullException(nameof(key));
    	}
        string basekeyName;
        int i = key.Name.IndexOf('\\');
        if (i != -1)
        {
    		basekeyName = key.Name.Substring(0, i).ToUpper(System.Globalization.CultureInfo.InvariantCulture);
        }
        else
        {
    		basekeyName = key.Name.ToUpper(System.Globalization.CultureInfo.InvariantCulture);
        }
        switch (basekeyName)
        {
    		case "HKEY_CLASSES_ROOT": return RegistryHive.ClassesRoot;
    		case "HKEY_CURRENT_USER": return RegistryHive.CurrentUser;
    		case "HKEY_LOCAL_MACHINE": return RegistryHive.LocalMachine;
    		case "HKEY_USERS": return RegistryHive.Users;
    		case "HKEY_PERFORMANCE_DATA": return RegistryHive.LocalMachine;
    		case "HKEY_CURRENT_CONFIG": return RegistryHive.CurrentConfig;
    		case "HKEY_DYN_DATA": return RegistryHive.DynData;
    		default: throw new System.ArgumentException(nameof(basekeyName));
        }
    }
    public static RegistryKey OpenBaseKey(this RegistryKey key)
    {
        return RegistryKey.OpenBaseKey(GetRegistryHive(key), key.View);
    }
