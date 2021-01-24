    // [RoutePrefix("Login")]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        // [Route("Verify")] //Matches GET login/verify
        public ActionResult Verify(string username, string password)
        {...}
    }
