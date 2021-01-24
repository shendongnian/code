    public class MyController : Controller
    {
    	private readonly IHostingEnvironment _env;
    	public MyController(IHostingEnvironment env)
    	{
    	    _env = env;
    	}
    }
