    public class FooController : Controller
    {
        private readonly IHostingEnvironment _env;
        public FooController(IHostingEnvironment env)
        {
            _env = env;
        }
        public IActionResult FooAction()
        {
            var tempatePath = Path.Combine(_env.ContentRootPath, "Areas/Services/Views/Quotations/SpecificForms/PC/PCReceipts.cshtml");
            IRazorLightEngine engine = EngineFactory.CreatePhysical(templatePath);
            ...
        }
    }
