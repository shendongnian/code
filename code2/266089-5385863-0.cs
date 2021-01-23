    Dictionary<PermissionNeeded, Func<User, bool>> Permissions = 
        new Dictionary<PermissionNeeded, Func<User, bool>> {
            { PermissionNeeded.Add, u => u.Add }, // don't need to specify == true
            { PermissionNeeded.Edit, u => u.Edit }, 
            ... 
            etc
        };
