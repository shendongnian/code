    public class TestContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TestContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Your Connection String Name"));
        }
    }
