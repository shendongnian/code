    void foo()
    {
        IPermissionProvider permissionProvider = ... the dispatcher, could be a singleton ...;
        User user = ...;
        MessageBox messageBox = ...;
        UserPermission userCanReadPermission = new UserPermission(UserPermissionType.CanRead);
        bool hasUserCanReadPermission = permissionProvider.HasPermission(userCanReadPermission, user, messageBox);
