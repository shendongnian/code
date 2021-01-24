    // Get a list of users in the role
    var usersWithPermission = _userManager.GetUsersInRoleAsync("Admin").Result;
    // Then get a list of the ids of these users
    var idsWithPermission = usersWithPermission.Select(u => u.Id);
    // Now get the users in our database with the same ids
    var users = _db.ApplicationUser.Where(u => idsWithPermission.Contains(u.Id)).ToListAsync();
    return users;
