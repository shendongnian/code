    public class SuppliersController : Controller
    {
        //
        // GET: /Suppliers/
        public ActionResult Error()
        {
            return View("Error"); // No "Error" view in Suppliers View folder, so it uses the one in shared folder
        }
    }
