    public class RoleSet
    {
        public RoleSet(IEnumerable<Role> roles)
        {
            Names = roles.Select(role => role.ToString());
        }
        public bool Includes(IPrincipal user)
        {
            return Names.Any(user.IsInRole);
        }
        public bool Includes(string role)
        {
            return Names.Contains(role);
        }
        public IEnumerable<string> Names { get; private set; }
    }
