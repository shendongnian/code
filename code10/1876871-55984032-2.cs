    public class Worker
    {
        private readonly ILogger<Worker> _logger = logger;
        private readonly IConfiguration _configuration = configuration;
        private readonly UnderstandingDIContext _dbContext = dbContext;
        public Worker(ILogger<Worker> logger, IConfiguration configuration, UnderstandingDIContext dbContext)
        {
            _logger = logger;
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public void Run()
        {
            _logger.LogInformation("Inside Worker Class");
            var settings = new Settings()
            {
                Secret1 = configuration["Settings:Secret1"],
                Secret2 = configuration["Settings:Secret2"]
            };
            _logger.LogInformation($"Secret 1 is '{settings.Secret1}'");
            _logger.LogInformation($"Secret 2 is '{settings.Secret2}'");
            _dbContext.Add(new UnderstandingDIModel()
            {
                Message = "Adding a message to the database."
            });
            _dbContext.SaveChanges();
        }
    }
