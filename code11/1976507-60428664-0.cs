      internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
          AutomaticMigrationsEnabled = false;
          AutomaticMigrationDataLossAllowed = false;
          ContextKey = "MyDbContext";
        }
        protected override void Seed(StratonLocalizerDatabase context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
