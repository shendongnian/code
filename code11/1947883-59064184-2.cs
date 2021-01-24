        public class ApplicationDbContextFactory:IDesignTimeDbContextFactory<ApplicationDbContext>
        {
          public ApplicationDbContext CreateDbContext(string[] args)
          {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ConsoleAppIdentity;Trusted_Connection=True;ConnectRetryCount=0");
            return new ApplicationDbContext(optionsBuilder.Options);
          }
        }
