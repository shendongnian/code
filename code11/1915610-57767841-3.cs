    public class HomeController : Controller
    {
    	//The same as the Action name
    	//return View(result);
    	public static readonly string viewNameWithGrid = "Grid";
    	public static readonly int defaultPageSize = 10;
    
    	//Initial Load
    	[HttpGet]
    	public ActionResult Grid(int? Page)
    	{
    		return GetViewWithGrid(Page);
    	}
    
    	//Change Page Size
    	[HttpPost]
    	public ActionResult Grid(int? Page, object fakeParam)
    	{
    		//Page = DropDownList.id
    		return GetViewWithGrid(Page);
    	}
    
    	ActionResult GetViewWithGrid(int? Page)
    	{
    		schoolEntities db = new schoolEntities();
    		List<Student> result = db.Students.ToList();
    
    		int pageSize = Page.HasValue ? Page.Value : defaultPageSize;
    		//ViewBag.pageSize = int.Parse(pagesizelist.SelectedValue);
    		ViewBag.pageSize = pageSize;
    		return View(viewNameWithGrid, result);
    	}
    }
