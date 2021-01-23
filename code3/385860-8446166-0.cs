    var users = session.Query<PersonUser>()
        .Fetch(u => u.Roles).Eager
        .AsEnumerable()
        .Select(u => new User
        {
            Id = u.UserId,
            FirstName = u.UserFirstName,
            Surname = u.UserSurname,
            ActiveRoles = u.Roles.Select(rr => new Role { Id = rr.RoleId, DisplayName = rr.RoleName }).ToList()
        })
        .ToList();
