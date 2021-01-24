    foreach (var role in model.Roles)
        {
            var aspnetuserrole = new AspNetUserRoles()
               {
                  UserId = model.Id,
                  RoleId = role.Id
               };
            _context.AspNetUserRoles.Add(aspnetuserrole);
        }
