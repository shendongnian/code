    public static int ExecuteSqlRaw(this DatabaseFacade databaseFacade,
        string sql, params object[] parameters); // 1
    public static int ExecuteSqlRaw(this DatabaseFacade databaseFacade,
        string sql, IEnumerable<object> parameters); // 2
    public static int ExecuteSqlInterpolated(this DatabaseFacade databaseFacade,
        FormattableString sql); // 3
