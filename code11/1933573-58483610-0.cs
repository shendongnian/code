public void ConfigureServices(IServiceCollection services)
{
	services.AddControllersWithViews();
	services.AddDbContext<CosmosDBContext>(options => options.UseCosmos(
		"https://jackcosmos.documents.azure.com:443/",
		"Y1tiY********lJurBg==",
		"DB"
	));
	services.AddTransient<IMyService, MyService>();
	services.AddTransient<IMyResolver, MyResolver>();
}
**CosmosDBContext.cs**
For convenience, I just tested with Cosmos DB SQL API. But, it should not affect the DI: 
public class CosmosDBContext : DbContext
{
	public CosmosDBContext(DbContextOptions<CosmosDBContext> options) : base(options)
	{
	}
	public DbSet<Item> Items { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultContainer("Item");
	}
}
public class Item
{
	public Item(string key, string content) => (this.key, this.content) = (key, content);
	public string id { get; set; } = Guid.NewGuid().ToString();
	public string key { get; set; }
	public string content { get; set; }
}
**MyService.cs**
public class MyService : IMyService
{
	private CosmosDBContext _cosmosDbContext;
	public MyService(CosmosDBContext cosmosDBContext)
	{
		_cosmosDbContext = cosmosDBContext;
	}
	public List<Item> GetByKey(string key)
	{
		return _cosmosDbContext.Items.Where(i => i.key.Equals(key)).ToList();
	}
}
**MyResolver.cs**
public class MyResolver : IMyResolver
{
	private IMyService _myService;
	public MyResolver(IMyService myService)
	{
		_myService = myService;
	}
	public List<Item> Resolve(string key)
	{
		return _myService.GetByKey(key);
	}
}
And In my **HomeController**, I just: 
private IMyResolver _myResolver;
public HomeController(ILogger<HomeController> logger, CosmosDBContext cosmosDBContext, IMyResolver myResolver)
{
	_myResolver = myResolver;
	// Add one
	cosmosDBContext.Database.EnsureCreated();
	cosmosDBContext.Items.Add(new Item("aaa", "abcdefg"));
	cosmosDBContext.SaveChanges(true);
	
	_logger = logger;
}
public IActionResult Index()
{
	var result = _myResolver.Resolve("aaa");
	return Ok(JsonConvert.SerializeObject(result));
}
The output:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/LCEWW.png
