    public class SomeController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
    
        public SomeController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
    
        public IActionResult SomeAction()
        {
            if (!hostingEnvironment.IsDevelopment())
                return NotFound();
    
            // Otherwise, return something else for Development.
        }
    }
