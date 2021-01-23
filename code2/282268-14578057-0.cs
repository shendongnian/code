    internal sealed class Configuration : DbMigrationsConfiguration<YourFancyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
...
    Database.SetInitializer(new MigrateDatabaseToLatestVersion<YourFancyDBContext, Configuration>());
