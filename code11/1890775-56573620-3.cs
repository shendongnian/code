    public List<User> GetCaseAssigneesByRoles(List<string> roles)
    {
        return UserCollection
            .Find(Builders<User>.Filter.All(u => u.Roles, roles))
            .ToEnumerable()
            .ToList();
    }
