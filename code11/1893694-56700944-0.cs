    string directoryName = GetTheDirectory();
    
    PermissionSet permissionSet = new PermissionSet(PermissionState.None);    
    
    FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, directoryName);
    
    permissionSet.AddPermission(writePermission);
    
    if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
    {
       // You have write permissions
    }
    else
    {
       // You don't have write permissions
    }
