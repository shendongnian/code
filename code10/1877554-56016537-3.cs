    public sealed class Model {
    	public string Remark { get; set; }
    	public int Cost { get; set; }
    }
    
    public class ServiceDetailsController : Controller {
    	
    	[HttpPost]
    	public ActionResult AddServiceHeaders(Model model){
    		// ..
    	}
    	
    }
