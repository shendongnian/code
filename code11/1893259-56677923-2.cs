    public interface IDatabaseInitializer
        {
            Task SeedAsync();
        }
    
        public class DatabaseInitializer : IDatabaseInitializer
        {
            private readonly MyDbContext _cotext;
           // Inject DbContext 
            public DatabaseInitializer(MyDbContext dbContext)
            {
                _cotext = dbContext;
            }
            public async Task SeedAsync()
            {
                // Object with contructor which having DbContext parameter
                SeedTest _seedTest = new SeedTest(_cotext);
                await _seedTest.SeedTest1();
            }
        }
