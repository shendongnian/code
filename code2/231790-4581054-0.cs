        public static MembershipUserCollection FindUsersByRole(string[] roles)
        {
            MembershipUserCollection msc = new MembershipUserCollection();
            (from MembershipUser user in Membership.GetAllUsers()
            where (Roles.GetRolesForUser(user.UserName).Intersect(roles).Count() > 0)
            select user).ToList().ForEach( u => msc.Add(u));
            return msc;
        }    
