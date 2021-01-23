    public static void SetDB (CSDataProvider db);
    public static void SetDB (CSDataProvider db, string contextName);
    public static void SetDB (string dbName);
    public static void SetDB (string dbName, Action creationDelegate);
    public static void SetDB (string dbName, SqliteOption sqliteOption);
    public static void SetDB (string dbName, SqliteOption sqliteOption, Action creationDelegate);
