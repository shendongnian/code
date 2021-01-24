        [Authorize]
        public class MyBackgroundClass : BackgroundService
        {
        private readonly IHubContext<BigScreenHub> _hub;
        private readonly List<WorkerInfo> WorkerInfos;
        private readonly HttpContext _httpContext;
        public MyBackgroundClass(IHubContext<BigScreenHub> hub, IOptions<AppSettings> settings, IHttpContextAccessor httpContextAccessor)
        {
                _httpContext = httpContextAccessor.HttpContext;
                _hub = hub;
                WorkerInfos = new WorkerInfoProvider(settings.Value.SomeStaticParam,"Need token here", settings.Value.ServicesUrl).WorkerInfos;
        }
        }
