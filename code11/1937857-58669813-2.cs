    public class DemoService : BackgroundService
    {
        private readonly ILogger<DemoService> _demoservicelogger;
        private readonly DemoContext _demoContext;
        private readonly IEmailService _emailService;
        public DemoService(ILogger<DemoService> demoservicelogger, 
            DemoContext demoContext, IEmailService emailService)
        {
            _demoservicelogger = demoservicelogger;
            _demoContext = demoContext;
            _emailService = emailService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _demoservicelogger.LogDebug("Demo Service is starting");
            stoppingToken.Register(() => _demoservicelogger.LogDebug("Demo Service is stopping."));
            while (!stoppingToken.IsCancellationRequested)
            {
                _demoservicelogger.LogDebug("Demo Service is running in background");
                var pendingEmailTasks = _demoContext.EmailTasks
                    .Where(x => !x.IsEmailSent).AsEnumerable();
                await SendEmailsAsync(pendingEmailTasks);
                await Task.Delay(1000 * 60 * 5, stoppingToken);
            }
            _demoservicelogger.LogDebug("Demo service is stopping");
        }
    }
