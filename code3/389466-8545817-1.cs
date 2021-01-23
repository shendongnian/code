    public static bool CanAccess(RolePermissions rp, CrudType permissionToCheck)
    {
        CrudType existingPermissions = (rp.CanCreate | rp.CanRead | 
                                        rp.CanUpdate | rp.CanDelete);
        
        return existingPermissions.HasFlag(permissionToCheck);
    }
