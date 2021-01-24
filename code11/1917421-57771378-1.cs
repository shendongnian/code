    public class ConfigureEmailOptions : IConfigureOptions<EmailOptions>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;
        public ConfigureEmailOptions(
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            IHostingEnvironment environment)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _environment = environment;
        }
        public void Configure(EmailOptions options)
        {
            options.ApiKey = _configuration["Email:SendGridApiKey"];
            options.TestMode = _configuration.GetValue<bool>("Email:TestMode", true);
            options.TestModeEmail = _configuration["Email:TestModeEmailAddresses"];
            options.Environment = _environment.EnvironmentName;
            options.Url = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host + _httpContextAccessor.HttpContext.Request.PathBase;
        }
    }
