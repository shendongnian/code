csharp
public class Program
{
	public static void Main(string[] args)
	{
		Config.Directories.EnsureDirectoryTree();
		var isService = !(Debugger.IsAttached || args.Contains("--console"));
		var webHostService = MyWebHostService.BuildWebHostService(args.Where(arg => arg != "--console").ToArray());
		if (isService)
		{
			ServiceBase.Run(webHostService);
		}
		else
		{
			webHostService.InitializeBackend();
			webHostService.Host.Run();
		}
	}
}
public class MyWebHostService : WebHostService
{
	public static readonly Logger Logger = LogManager.GetCurrentClassLogger();
	public IWebHost Host { get; }
	public static ZlsWebHostService BuildWebHostService(string[] args)
	{
		ConfigureNLog();
		Logger.Info("{0} (v{1}) starting...", Config.ServiceName, GetApplicationVersion());
		// restore config files
		Config.Files.EnsureRestored();
		var host = CreateWebHostBuilder(args).Build();
		return new ZlsWebHostService(host);
	}
	public static IWebHostBuilder CreateWebHostBuilder(string[] args)
	{
		var pathToExe = Assembly.GetExecutingAssembly().Location;
		var pathToContentRoot = Path.GetDirectoryName(pathToExe);
		
		return WebHost.CreateDefaultBuilder()
			.UseKestrel()
			.UseContentRoot(pathToContentRoot)
			.ConfigureAppConfiguration((context, config) =>
			{
				config.SetBasePath(Config.Directories.ActiveConfig);
				config.AddJsonFile(Config.Files.KestrelConfig.RelativePath, true, true);})
			.ConfigureLogging((hostingContext, logging) =>
			{
				logging.ClearProviders();
				logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
				logging.AddConsole();
				if(hostingContext.HostingEnvironment.IsDevelopment())
					logging.AddDebug();
			})
			.UseNLog()
			.UseStartup<Startup>();
	}
	public MyWebHostService(IWebHost host) : base(host)
	{
		this.Host = host;
	}
	protected override void OnStarting(string[] args)
	{
		InitializeBackend();
		base.OnStarting(args);
	}
	protected override void OnStarted()
	{
		Logger.Info("{0} started...", Config.ServiceName);
		base.OnStarted();
	}
	protected override void OnStopped()
	{
		Logger.Info("{0} stopped...", Config.ServiceName);
		base.OnStopped();
	}
...
}
public class Startup
{
...
	// This method gets called by the runtime. Use this method to add services to the container.
	// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
	public IServiceProvider ConfigureServices(IServiceCollection services)
	{
		...
		
		services.AddSingleton<PaymentQueueService>();
		...
		var container = new Container(c =>
		{
			c.IncludeRegistry<MyFooRegistry>();
			c.Populate(services);
		});
		return container.GetInstance<IServiceProvider>();
	}
...
}
