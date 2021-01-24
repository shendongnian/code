    public List<User> GetCaseAssigneesByRoles(string role)
    {
        return UserCollection
            .Find(Builders<User>.Filter.AnyEq(u => u.Roles, role))
            .ToEnumerable()
            .ToList();
    }
