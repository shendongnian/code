            using (var ctx = new MyDbContext())
            {
                var roles = ctx.Roles.Where(w => w.IsActive == true).Select(r => new Data
                {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName
                }).Ditinct();
                foreach (var role in roles)
                {
                    role.UserCount = ctx.Users.Count(u => u.RoleID == role.roleID);
                }
            }
