        public static MembershipUserCollection FindUsersByRole(string[] roles)
        {
            MembershipUserCollection msc = new MembershipUserCollection();
            roles.Select(role => Roles.GetUsersInRole(role))
            .Aggregate((a, b) => a.Union(b).ToArray())
            .Distinct()
            .Select( user => Membership.GetUser(user))
            .ToList().ForEach( user => msc.Add(user));
            return msc;
        }
