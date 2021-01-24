        public class TestController : Controller
    {
        // GET: Test
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            string s = "User!1Nom";
            for (int i = 1; i < 501; i++)
            {
                s = s + i;
                var user = new ApplicationUser { UserName = s, Email = s+"@gmail.com" };
                var result = userManager.Create(user, s);
            }
            return View();
        }
    }
