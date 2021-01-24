    public class ExamplePageModel : PageModel
    {
        private readonly ILogger<ExamplePageModel> _logger;
        public ExamplePageModel(ILogger<ExamplePageModel> logger)
        {
            _logger = logger;
        }
        public async Task OnPostAsync()
        {
            _logger.LogInformation("Doing something");
            // …
        }
    }
