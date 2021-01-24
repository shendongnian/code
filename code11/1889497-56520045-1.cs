	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View(new SampleViewModel(){Name = "Item 1", Price = 2.99});
		}
	}
