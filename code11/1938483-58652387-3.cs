    private static IEnumerable<string> GetUserApplicationRoles(string applicationName, User data)
    {
        return data
            .UserInfo
            .Where(entry => entry.Key.Equals(applicationName))
            .SelectMany(entry => entry.Value.Roles);
    }
