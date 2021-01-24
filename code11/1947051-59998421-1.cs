         public class DesignTimeDbContextFactory : 
           IDesignTimeDbContextFactory<KontestDbContext>
         {
             public ApplicationDbContext CreateDbContext(string[] args)
             {
                     IConfiguration configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json").Build();
                     var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                     var connectionString = 
                         configuration.GetConnectionString("DefaultConnection");
                         builder.UseSqlServer(connectionString);
                     return new ApplicationDbContext(builder.Options, new OperationalStoreOptionsMigrations()); 
                }
           }
