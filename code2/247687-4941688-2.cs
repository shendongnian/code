    static bool CheckWritePermission(string path, string username, string password, string[] properties)
    {
        using (DirectoryEntry de = new DirectoryEntry(path, username, password))
        {
            de.RefreshCache(new string[] {"allowedAttributesEffective"});
            return properties.All( property => de.Properties["allowedAttributesEffective"].Contains(property));
        }
    }
