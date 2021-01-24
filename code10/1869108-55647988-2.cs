    namespace MyProjectName.Pages
    {
        public class Index1Model : PageModel
        {
            public string Message { get; set; } = "Initial Request";
            public void OnGet()
            {
                Message = "Test1";
            }
    
            public IActionResult OnPost()
            {
                return Content("BuilderJob");
            }
        }
    }
