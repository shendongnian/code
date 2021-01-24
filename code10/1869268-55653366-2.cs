    	[Authorize(AuthenticationSchemes = "user_by_cookie")]
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
			return View();
		}
		
	}
