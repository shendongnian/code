    public async Task <List<SysUserPermission>> SavePermissions(SysUserPermission obj)
        {
    
                  var result =  db.Set<SysUserPermission>()
    
                    for (int i = 0; i < obj.PermissionsToAdd.Count; i++)
                    {
                        obj.PermissionId = obj.PermissionsToAdd[i];
                    }
                  await result.AddRangeAsync(obj.PermissionsToAdd);
        }
