    class MigrationHelper: IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args) => 
            Program.CreateServiceProvider()
            .CreateScope()
            .ServiceProvider
            .GetService<AppDbContext>();
    }
