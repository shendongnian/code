Permissions =
                      (from srp in DataSet.SubRolePermissions
                      join p in DataSet.Permissions on srp.PermiisonId equals p.Id
                      where srp.SubRoleId == sr.Id
                      select new Permission
                      {
                          Name = p.Name
                      }).ToList()
The Permissions is a `List<T>`, while the query returns an `IEnumerable<T>`. You need to convert to `List<T>`, which could be done using the `ToList()` method
Complete Query
Role =
            (from u in DataSet.Users
             join r in DataSet.Roles on u.RoleId equals r.Id
             where u.Id == 1
             select new Role
             {
                 Name = r.Name,
                 SubRoles =
                 (from rsb in DataSet.RoleSubRoles
                 join sr in DataSet.SubRoles on rsb.SubRoleId equals sr.Id
                 where r.Id == rsb.RoleId
                 select new SubRole
                 {
                      Name = sr.Name,
                      EndPoint = sr.EndPoint,
                      Permissions =
                      (from srp in DataSet.SubRolePermissions
                      join p in DataSet.Permissions on srp.PermiisonId equals p.Id
                      where srp.SubRoleId == sr.Id
                      select new Permission
                      {
                          Name = p.Name
                      }).ToList()
                 })
             })
        };
