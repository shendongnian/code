        public static List<MembershipUser> FindUsersByRole(string[] roles)
        {
            var userList = (from MembershipUser user in Membership.GetAllUsers()
                            where (Roles.GetRolesForUser(user.UserName).Intersect(roles).Count() > 0)
                            select user).ToList();
            return userList;
        }   
