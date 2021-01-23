    internal sealed class Configuration 
        : DbMigrationsConfiguration<Path.To.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
