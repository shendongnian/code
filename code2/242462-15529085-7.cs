    static readonly string[] serverAliases = { "server", "host", "data source", "datasource", "address", 
                                               "addr", "network address" };
    static readonly string[] databaseAliases = { "database", "initial catalog" };
    static readonly string[] usernameAliases = { "user id", "uid", "username", "user name", "user" };
    static readonly string[] passwordAliases = { "password", "pwd" };
    public static string GetPassword(string connectionString)
    {
        return GetValue(connectionString, passwordAliases);
    }
    public static string GetUsername(string connectionString)
    {
        return GetValue(connectionString, usernameAliases);
    }
    public static string GetDatabaseName(string connectionString)
    {
        return GetValue(connectionString, databaseAliases);
    }
    public static string GetServerName(string connectionString)
    {
        return GetValue(connectionString, serverAliases);
    }
    static string GetValue(string connectionString, params string[] keyAliases)
    {
        var keyValuePairs = connectionString.Split(';')
                                            .Where(kvp => kvp.Contains('='))
                                            .Select(kvp => kvp.Split(new char[] { '=' }, 2))
                                            .ToDictionary(kvp => kvp[0].Trim(),
                                                          kvp => kvp[1].Trim(),
                                                          StringComparer.InvariantCultureIgnoreCase);
        foreach (var alias in keyAliases)
        {
            string value;
            if (keyValuePairs.TryGetValue(alias, out value))
                return value;
        }
        return string.Empty;
    }
