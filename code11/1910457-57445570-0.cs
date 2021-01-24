    var result = from a in db.Roles
                 group a.Name by new { a.Id, a.Name } into g
                 select new RolesViewModel
                 {
                     Id = g.Key.Id,
                     RoleName = g.Key.Name,
                     Count = db.Users.Count(x => x.Roles.Select(k => k.RoleId).Contains(g.Key.Id))
                 }.ToList();
