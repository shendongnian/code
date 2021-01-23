    var usersInRole = Roles.GetUsersInRole("admin");
    var users = Membership.GetAllUsers()
        .Cast<MembershipUser>()
        .Select(u => 
            !usersInRole.Contains(u.UserName)
        );
