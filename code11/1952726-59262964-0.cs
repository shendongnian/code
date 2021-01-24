	public class EventHubClientHolder
	{
		public string Name;
		public EventHubClient eventHubClient;
	}
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllersWithViews();
		services.AddSingleton<EventHubClientHolder>(_ => { return new EventHubClientHolder() { Name = "A", eventHubClient = ..... }; });
		services.AddSingleton<EventHubClientHolder>(_ => { return new EventHubClientHolder() { Name = "B", eventHubClient = ..... }; });
	}
	public HomeController(ILogger<HomeController> logger, IEnumerable<EventHubClientHolder> services)
	{
		_logger = logger;
		_services = services;
	}
	public IActionResult Index()
	{
		var eventHubClient = _services.First(_ => _.Name.Equals("A"))).eventHubClient;
		return View();
	}
