    public class CustomerController : Controller {
		
      public ActionResult Edit(int id) {
        int customerId = id //the id in the URL
        return View();
      }
    }
    public class ProductController : Controller {
		
      public ActionResult Edit(int id, bool allowed) { 
        int productId = id; // the id in the URL
        bool isAllowed = allowed  // the ?allowed=true in the URL
        return View();
      }
    }
