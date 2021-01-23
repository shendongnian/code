    public static bool registryValueExists(string hive_HKLM_or_HKCU, string registryRoot, string valueName)
    {
        RegistryKey root;
        switch (hive_HKLM_or_HKCU.ToUpper())
        {
            case "HKLM":
                root = Registry.LocalMachine.OpenSubKey(registryRoot, false);
                break;
            case "HKCU":
                root = Registry.CurrentUser.OpenSubKey(registryRoot, false);
                break;
            default:
                throw new System.InvalidOperationException("parameter registryRoot must be either \"HKLM\" or \"HKCU\"");
        }
        if (root.GetValue(valueName) == null)
            return false;
        else
            return true;
    }
