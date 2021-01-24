    public class IndexModel : PageModel
    {
        private readonly IContextSettings settings;
        public IndexModel(IContextSettings settings)
        {
            this.settings = settings;
        }
        public IActionResult OnGet()
        {
            var userId = settings.ContextUserID;
            return Page();
        }
    }
