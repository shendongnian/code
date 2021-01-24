    private static RegistryKey GetCommonKey(string subKey)
    {
        return Registry.LocalMachine.OpenSubKey(subKey);
    }
    private static string GetRegistryValue(RegistryKey commonKey, string subKey, string keyName)
    {
        using (commonKey.OpenSubKey(subKey))
        {
            if (key != null)
            {
                if (key.GetValue(keyName) != null)
                {
                    return (string)key.GetValue(keyName);
                }
            }
            return null;
        }
    }
    // usage
    var commonKey = GetCommonKey("SOFTWARE\\WOW6432Node\\Microsoft");
    var version = GetRegistryValue(commonKey, "DataAccess", "Version");
    var nodePath = GetRegistryValue(commonKey, "ENROLLMENTS\\ValidNodePaths", "Version");
