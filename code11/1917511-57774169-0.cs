c#
public class SeedingTestDataAppService : MyAppServiceBase
{
    private MyDbContext _ctx => _dbContextProvider.GetDbContext();
    private readonly IDbContextProvider<MyDbContext> _dbContextProvider;
    public SeedingTestDataAppService(IDbContextProvider<MyDbContext> dbContextProvider)
    {
        _dbContextProvider = dbContextProvider;
    }
}
