    public class MyController : Controller
    {
    	[HttpGet]
    	public IActionResult Me([FromServices] IHostingEnvironment env)
    	{
    		return View();
    	}
    }
