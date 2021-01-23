    MembershipUserCollection users = Membership.GetAllUsers();
    MembershipUserCollection usersNoRoles = new MembershipUserCollection();
        foreach (MembershipUser user in users)
        {
            string[] roles = Roles.GetRolesForUser(user.UserName);
            // if roles empty
            if (roles.Count() == 0)
            {
                // Add User to a List for User with no Roles
                usersNoRoles.Add(user);
            }
       }
