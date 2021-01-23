 [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminsAttribute : AuthorizeAttribute
    {
            public AdminsAttribute() 
            {
                this.Roles = "MSH\\GRP_Level1,MSH\\Grp_Level2"; 
            }
    } 
 public class HomeController : Controller
    {
        [Admins] 
        public ActionResult Level1()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
        }
