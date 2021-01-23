    private Assembly LoadAssemblyFromFile(string file)
    {
        FileIOPermission perm = new FileIOPermission(FileIOPermissionAccess.AllAccess, file);
        perm.Assert();
        return Assembly.LoadFile(file);
    }
