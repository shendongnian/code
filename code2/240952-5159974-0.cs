    public static class AppStart_SQLCEEntityFramework {
        public static void Start() {
            DbDatabase.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            // Sets the default database initialization code for working with Sql Server Compact databases
            // Uncomment this line and replace CONTEXT_NAME with the name of your DbContext if you are 
            // using your DbContext to create and manage your database
            //DbDatabase.SetInitializer(new CreateCeDatabaseIfNotExists<CONTEXT_NAME>());
        }
    }
