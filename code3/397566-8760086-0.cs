    // add roles that are in dto.Roles, but not in resource.Roles
    // use the change tracker entry, or add a stub role
    var rolesToAdd = fromDto.Roles.Where(r => !toResource.Roles.Any(role => role.Id == r)).ToList();
    var roleEntries = dbContext.ChangeTracker.Entries<Role>();
    
    foreach (var id in rolesToAdd)
    {
        var role = roleEntries.Where(e => e.Entity.Id == id).Select(e => e.Entity).FirstOrDefault();
    
        if (role == null)
        {
            role = new Role { Id = id };
            dbContext.Set<Role>().Attach(role);
        }
    
        toResource.Roles.Add(role);
    }
