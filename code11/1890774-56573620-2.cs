    public List<User> GetCaseAssigneesByRoles(List<string> roles)
    {
        return UserCollection
            .Find(Builders<User>.Filter.AnyIn(u => u.Roles, roles))
            .ToEnumerable()
            .ToList();
    }
