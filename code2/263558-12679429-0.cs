    var usersInRole = Roles.GetUsersInRole("admin");
    var users = Membership.GetAllUsers()
        .Cast<MembershipUser>()
        .Where(u => 
            !usersInRole.Contains(u.UserName)
        );
