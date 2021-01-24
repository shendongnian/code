    [Area(nameof(CRM))]  // CRM is the another-folder name inside Areas folder
	[Route("CRM/[controller]/[action]")]
	[Authorize]
	[ServiceFilter(typeof(ActionFilter))]
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
    }
