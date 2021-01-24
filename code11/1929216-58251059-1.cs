    public class Startup
    {
        public void Configure(Configurations dbMigrationsConfig)
        {
            try
            {
                dbMigrationsConfig.SeedData().Wait();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
    public class Configurations
    {
        private readonly TemplateContext dbContext;
        public Configurations(TemplateContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task SeedData()
        {
            //You seeding code
        }
    }`
