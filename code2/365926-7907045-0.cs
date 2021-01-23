    public class MyModel
    {
    	public List<ListAEntity> ListA {get;set;}
    	public List<ListBEntity> ListB {get;set;}
    }
    	
    
    public class HomeController : Controller
    {
    	private readonly MyDataContext _context = new MyDataContext();
    	
    	public ActionResult Index()
    	{
    		var model = new MyModel()
    		{
    			ListA = _context.Get<ListAEntity>(),
    			ListB = _context.Get<ListBEntity>()
    		};
    		
    		return View(model);
    	}
    }
