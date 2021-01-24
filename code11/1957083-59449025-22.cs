    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    
    namespace stackoverflow_aspnetcore_59448960.Pages.Login
    {
        // Very important
        [AllowAnonymous]
        // Another fact: The name of this Model, I mean "Index" need to be
        // the same as the filename without extensions: Index[Model] == Index[.cshtml.cs]
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
