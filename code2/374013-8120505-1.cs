    Role newRole = user.CurrentRole; // Store the new role to temp variable
    user.CurrentRole = new Role { Id = oldRoleId }; // Simulate old role from passed Id
    newContext.Users.Attach(user);
    newCotnext.Entry(user).State = EntityState.Modified;
    newContext.Roles.Add(newRole);
    user.CurrentRole = newRole; // Reestablish the role so that context correctly set the state of the relation with the old role
    newContext.SaveChanges();
