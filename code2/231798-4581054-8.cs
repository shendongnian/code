        public static List<MembershipUser> FindUsersByRole(string[] roles)
        {
            var userList = roles.Select(role => Roles.GetUsersInRole(role))
                                .Aggregate((a, b) => a.Union(b).ToArray())
                                .Distinct()
                                .Select( user => Membership.GetUser(user))
                                .ToList();
            return userList;
        }  
