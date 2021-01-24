public class DbContextFactory
{
    private readonly IConfiguration _configuration;
    private readonly Dictionary<string, ClientDbContext> _clientContexts = new Dictionary<string, ClientDbContext>();
    public DbContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public ClientDbContext GetOrCreateClientContext(string clientNumber)
    {
        // if you have context already created - return it
        if (_clientContexts.ContainsKey(clientNumber))
            return _clientContexts[clientNumber];
        var optionsBuilder = new DbContextOptionsBuilder<ClientDbContext>();
        var clientConnection = string.Format(_configuration.GetConnectionString("clientConnection"), clientNumber);
        optionsBuilder.UseSqlServer(clientConnection);
        var clientDbContext = new ClientDbContext(optionsBuilder.Options);
        _clientContexts[clientNumber] = clientDbContext;
        return clientDbContext;
    }
}
Then in your worker class you can group your data by `ClientNumber`, for each client create (or get already created) `DbContext` and repository, then do data update.
public class Worker
{
    private readonly DbContextFactory _factory;
    public Worker(DbContextFactory factory)
    {
        _factory = factory;
    }
    
    public async Task DoWorkAsync()
    {
        // group by ClientNumber
        var groupedCases = caseList.GroupBy(x => x.ClientNumber);
        foreach (var groupedCase in groupedCases)
        {
            // For each client create context and repository
            var clientContext = _factory.GetOrCreateClientContext(groupedCase.Key);
            var clientRepository = new ClientRepository(clientContext);
            foreach (var @case in groupedCases)
            {
                var updatedCase = // transform case here
                await clientRepository.CreateCases(updatedCase);
            }
        }
    }
}
You can use dependency injection or just create these clases like that:
var factory = new DbContextFactory(yourConfiguration);
var worker = new Worker(factory);
await worker.DoWorkAsync();
