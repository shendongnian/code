        public IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
[...]
            services.Configure<AllSettings>(Configuration);
        }
TestController.cs
[...]
  TestController(IOptions<AllSettings> settings){
    _settings = settings.Value;
  }
  [HttpGet(nameof(TestAction))]
  public MySettings TestAction() {
    return _settings.MySettings;
  }
[...]
