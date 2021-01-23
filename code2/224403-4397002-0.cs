    string filename = ...
    var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, filename);
    if (SecurityManager.IsGranted(writePermission))
    {
        // You have write permission
    }
