    public class MyController : Controller
    {
    	[HttpGet]
    	public IActionResult Me([FromServices] IWebHostEnvironment env)
    	{
    		return View();
    	}
    }
