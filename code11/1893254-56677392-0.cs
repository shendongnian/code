c#
public class DatabaseInitializer : IDatabaseInitializer
{
    private readonly MyDbContext _context;
    
    public DatabaseInitializer(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task SeedAsync()
    {
        SeedTest _seedTest = new SeedTest(_context);
        await _seedTest.SeedTest();
    }
}
