    var usersInRolesQuery = Roles.GetAllRoles()
                                 .SelectMany(role => Roles.GetUsersInRole(role));
    var usersInRoles = new HashSet<string>(usersInRolesQuery);
    return Membership.GetAllUsers()
                     .Cast<MembershipUser>()
                     .Where(user => !usersInRoles.Contains(user.UserName));
