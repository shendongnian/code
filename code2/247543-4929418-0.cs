    var folderController = new FolderController();
    var folderId =
        folderController.AddFolder(
            new FolderInfo(
                portalId, 
                folderName, 
                (int)FolderController.StorageLocationTypes.InsecureFileSystem,
                isProtected: false, 
                isCached: false, 
                lastUpdated: Null.NullDate));
    var folder = folderController.GetFolderInfo(portalId, folderId);
    Directory.CreateDirectory(folder.PhysicalPath);
    var permissionController = new PermissionController();
    var writePermission = permissionController.GetPermissionByCodeAndKey("SYSTEM_FOLDER", "WRITE").Cast<PermissionInfo>().Single();
    var registeredUserRole = new RoleController().GetRoleByName(folder.PortalID, "Registered Users");
    folder.FolderPermissions.Add(new FolderPermissionInfo
        {
            FolderID = folder.FolderID,
            PermissionID = writePermission.PermissionID,
            RoleID = registeredUserRole.RoleID,
            UserID = Null.NullInteger,
            PermissionKey = writePermission.PermissionKey,
            AllowAccess = false
        });
