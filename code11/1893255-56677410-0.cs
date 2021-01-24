    public class DatabaseInitializer : IDatabaseInitializer{
         private readonly SpeedTest _seedTest;
         public DatabaseInitializer(SeedTest seedTest) 
         {
              _seedTest = seedTest;
         }
         public async Task SeedAsync()
         {
             await _seedTest.SeedTest();
         }
    }
