    public List<User> UsersPerRole(string role)
    {
         return entities.Roles
                        .Where(r => r.RoleId == role)
                        .SelectMany(r => r.Users)
                        .ToList();
    }
