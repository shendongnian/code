    public Role[] UserRoles { get; set; }  
    private static UserRoleModel[] GetUsersRole(Role[]usersRole)
    {
        List<UserRoleModel> rolesList = new List<UserRoleModel>();
        Role[] roles = (Role[]) Enum.GetValues(typeof(Role));
        // or if you need the specific three values like in your example:
        // Role[] roles = new Role[] { Role.User1, Role.User2, Role.User3, Role.User4 };
        foreach (var role in roles)
        {
            rolesList.Add(new UserRoleModel
            {
                Role = role.ToString(),
                UserRole = usersRole.Contains(role)
            });
        }
        return rolesList.ToArray();
    }
