    public class SearchController : Controller
    {
    	public ActionResult Index(string format, SearchModel search)
    	{
    		var results = searchFacade.SearchStuff(search);
    
    		if(format.Equals("xml"))
    			return Xml(results); //using an XmlResult or whatever
    		if(format.Equals("html"))
    			return View(results);
    		return Json(results, JsonRequestBehavior.AllowGet);
    	}
    }
