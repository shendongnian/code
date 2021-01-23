    namespace Project.Controllers
    {
        public class EmployeeReferralController : Controller
        {
            private ProjDbContext db = new ProjDbContext();
    
            //
            // GET: /EmployeeReferral/
    
            public ActionResult Index()
            {
                return View();
            }
    
     public ActionResult Create()
            {
                ViewBag.Districts = db.Districts;            
                return View();
            }
