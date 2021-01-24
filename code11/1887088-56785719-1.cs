        internal class TimedHostedService : IHostedService, IDisposable
        {
            private readonly ILogger _logger;
            private Timer _timer;
            private readonly IConfiguration _configuration;
            private readonly CommandLineArgs _commandLineArgs;
            public TimedHostedService(ILogger<TimedHostedService> logger
                , IConfiguration configuration
                , CommandLineArgs commandLineArgs)
            {
                _logger = logger;
                _configuration = configuration;
                _commandLineArgs = commandLineArgs;
            }       
        }
