        public static void AddUserToRole(string username, RoleName level)
        {
            var roles = RolesLesserThanOrEqualTo(level);
            foreach (var role in roles)
            {
                Roles.AddUserToRole(username, role.Name());
            }
        }
        public static IEnumerable<RoleName> RolesLesserThanOrEqualTo(RoleName level)
        {
            return Enum.GetValues(typeof(RoleName)).Cast<RoleName>().Where(role => level >= role);
        }
