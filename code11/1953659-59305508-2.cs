    public class MyController : Controller
    {
    	private readonly IWebHostEnvironment _env;
    	public MyController(IWebHostEnvironment env)
    	{
    	    _env = env;
    	}
    }
