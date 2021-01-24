    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    
    namespace stackoverflow_aspnetcore_59448960.Pages
    {
        // No [Authorize] needed, because of FallbackPolicy (see Startup.cs)
        public class IndexModel : PageModel
        {
            private readonly ILogger<IndexModel> _logger;
    
            public IndexModel(ILogger<IndexModel> logger)
            {
                _logger = logger;
            }
    
            public void OnGet()
            {
    
            }
        }
    }
