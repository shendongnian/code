    public class SeedTest
        {
            private readonly MyDbContext _context;
    
            public SeedTest(MyDbContext context)
            {
                _context = context;
            }
    
            public async Task SeedTest1()
            {
                Values value1 = new Values
                {
                    Id = Guid.Parse("AFE1052A-A694-48AF-AA77-56D2D945DE31"),
                    ValueName = "value 1",
                    Created = DateTime.Now
                };
    
                _context.Values.Add(value1);
    
                var value  = await _context.SaveChangesAsync();
            }
    
            public SeedTest()
            {
            }
        }
