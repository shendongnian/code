    public class ErrorsController : Controller
    {
        private readonly ILogger<ErrorController> _logger;
        private readonly IHostingEnvironment _environment;
        private readonly IHttpContextAccessor _httpContext;
        private readonly JiraSettings _jiraSettings;
        public ErrorController(
            ILogger<ErrorController> logger,
            IHostingEnvironment environment,
            IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _environment = environment;
            _httpContext = httpContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exception?.Error == null)
            {
                return NoContent();
            }
            var errorMessage = $"An error occurred while processing your request {exception.Error.GetErrorId()}";
            if (_environment.IsProduction() || _environment.IsStaging())
            {
                return Json(errorMessage);
            }
            errorMessage += $"\n{exception.Error.StackTrace}";
            return Json(errorMessage);
        }
