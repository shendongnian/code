    namespace MvcApplication1.Controllers
    {
        [HandleError]
        public class YourController : Controller
        {
            public ActionResult YourView()
            {
                ViewData["FORMER_BORROWER"] = new SelectList(db.Borrowers.ToList, "BorrowerID, "Name");               
    
                return View();
            }
        }
    }
