        var user = Users.FirstOrDefault(u => u.Id == id);
        var oldRole = user.Roles.FirstOrDefault();
        if (user != null && oldRole.Id != newRoleID)
        {
            user.Roles.Remove(oldRole);
            user.Roles.Add(new IdentityUserRole { RoleId = newRoleID });
        }
