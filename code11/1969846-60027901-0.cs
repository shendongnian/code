c#
public class MainProjectsAppService : ApplicationService
{
    private readonly IDbContextProvider<DecentralizationDbContext> _dbContextProvider;
    private DecentralizationDbContext _ctx => _dbContextProvider.GetDbContext();
    public MainProjectsAppService(IDbContextProvider<DecentralizationDbContext> dbContextProvider)
    {
        _dbContextProvider = dbContextProvider;
    }
}
Reference: [aspnetboilerplate/aspnetboilerplate#4809](https://github.com/aspnetboilerplate/aspnetboilerplate/issues/4809)
