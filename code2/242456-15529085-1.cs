    static string[] server = { "server", "host", "data source", "datasource", "address", "addr", 
                               "network address" };
    static string[] db = { "database", "initial catalog" };
    static string[] user = { "user id", "uid", "username", "user name", "user" };
    static string[] pass = { "password", "pwd" };
    public static string GetPassword(string connectionString)
    {
        return GetValue(connectionString, pass);
    }
    public static string GetUsername(string connectionString)
    {
        return GetValue(connectionString, user);
    }
    public static string GetDatabaseName(string connectionString)
    {
        return GetValue(connectionString, db);
    }
    public static string GetServerName(string connectionString)
    {
        return GetValue(connectionString, server);
    }
    static string GetValue(string connectionString, params string[] keys)
    {
        foreach (var item in keys)
        {
            int index = connectionString.IndexOf(item, StringComparison.InvariantCultureIgnoreCase);
            if (index != -1)
            {
                int indexOfDelimiter = connectionString.IndexOf(';', index + item.Length);
                return connectionString.Substring(index + item.Length,
                                                  (indexOfDelimiter == -1 ? connectionString.Length :
                                                                            indexOfDelimiter) - index - item.Length)
                                       .Trim().TrimStart('=').TrimStart();
            }
        }
        return string.Empty;
    }
