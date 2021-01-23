    public class CompositeRoleSet
    {
        public static CompositeRoleSet CreateDefault()
        {
            var set = new CompositeRoleSet();
            set.Register(Role.ReadWrite, Role.Read, Role.Write);
            return set;
        }
    
        private readonly Dictionary<Role, Role[]> compositeRoles = new Dictionary<Role, Role[]>();
    
        private void Register(Role composite, params Role[] contains)
        {
            compositeRoles.Add(composite, contains);
        }
    
        public RoleSet Resolve(params Role[] roles)
        {
            return new RoleSet(roles.SelectMany(Resolve));
        }
    
        private IEnumerable<Role> Resolve(Role role)
        {
            Role[] roles;
            if (compositeRoles.TryGetValue(role, out roles) == false)
            {
                roles = new[] {role};
            }
    
            return roles;
        }
    }
