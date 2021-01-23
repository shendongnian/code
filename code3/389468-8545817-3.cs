    public static bool CanAccess(RolePermissions rp, CrudType permissionToCheck)
    {
        CrudType existingPermissions = 
                                    SetPermissionFlag(CrudType.CanCreate, rp.CanCreate) |
                                    SetPermissionFlag(CrudType.CanRead, rp.CanRead) | 
                                    SetPermissionFlag(CrudType.CanUpdate, rp.CanUpdate |
                                    SetPermissionFlag(CrudType.CanDelete, rp.CanDelete);
        
        return existingPermissions.HasFlag(permissionToCheck);
    }
    public static CrudType SetPermissionFlag(CrudType crudType, bool permission)
    {
        return (CrudType)((int)crudType * Convert.ToInt32(permission));
    }
