    string[] roles = new[] { "2", "4", "5" };
    var users = db.AspNetUsers
        // for each user
        .Where(user => user.Roles // get the roles
            // select the role id
            .Select(role => role.RoleId)
            // and filter by the wanted roles
            .Where(role => roles.Contains(role))
            // by ensuring any role with one of the wanted IDs exist
            .Any())
        // and then get the IDs of those users
        .Select(user => user.UserId)
        // to finally execute the query
        .ToList();
