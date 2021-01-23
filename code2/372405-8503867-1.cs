            _permissionController = new PermissionController(_file);
            _permissionController.Allow(FileSystemRights.Read, FileSystemRights.Write);
            _permissionController.Deny(FileSystemRights.FullControl,
                                       FileSystemRights.Modify,
                                       FileSystemRights.ReadAndExecute);
            _permissionController.Apply();
