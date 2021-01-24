        public class CustomContext : DbContext
        {
            public string CompanyName { get; private set; }
            private IOptions<SqlSettings> _sqlSettings;
            public CustomContext(DbContextOptions<CustomContext> options, IOptions<SqlSettings> sqlSettings, IHttpContextAccessor httpContextAccessor)
              : base(options)
            {
              GetDbName(httpContextAccessor.HttpContext.Request);
              if (string.IsNullOrEmpty(CompanyName))
                  return;
              sqlSettings.Value.SetDbName(CompanyName);
              _sqlSettings = sqlSettings;
            }
            private void GetDbName(HttpRequest httpRequest)
            {
              try
              {
                  CompanyName = httpRequest.Headers["CompanyName"];
              }
              catch (Exception)
              {
                  CompanyName = "";
              }
            }
            public DbSet<User> Users { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
              optionsBuilder.UseSqlServer(_sqlSettings.Value.ConnectionString);
            }
        } 
       
