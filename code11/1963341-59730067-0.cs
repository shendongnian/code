public class HomeController : Controller
{
        private const connectionString = "YourConnectionString";
        public ActionResult Index()
        {
            
            var objDAL = new DAL_InvoicesEntity();
            List<InvoicesModel> invInfo = objDAL.RetriveRecords(connectionString);
            ViewBag.invInfo = invInfo;
            return View();
        } 
} 
