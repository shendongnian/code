    private static IEnumerable<string> GetUserApplicationRoles(string applicationName, User data)
    {
        return data
            .UserInfo
            .TryGetValue(applicationName, out var value) ? value.Roles : Enumerable.Empty<string>();
    }
