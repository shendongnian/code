     public class ContextFactoryNeededForMigrations : IDesignTimeDbContextFactory<AppDbContext >
        {
            private const string ConnectionString =
                "Server=(localdb)\\mssqllocaldb;Database=EfCoreInActionDb;Trusted_Connection=True;MultipleActiveResultSets=true";
    
            public EfCoreContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EfCoreContext>();
                optionsBuilder.UseSqlServer(ConnectionString,
                    b => b.MigrationsAssembly("DataLayer"));
    
                return new EfCoreContext(optionsBuilder.Options);
            }
