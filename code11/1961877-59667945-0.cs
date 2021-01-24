    public static int ExecuteSqlCommand(this DatabaseFacade databaseFacade,
        RawSqlString sql, params object[] parameters); // 1
    public static int ExecuteSqlCommand(this DatabaseFacade databaseFacade,
       RawSqlString sql, IEnumerable<object> parameters); // 2
    public static int ExecuteSqlCommand(this DatabaseFacade databaseFacade,
        FormattableString sql); // 3
