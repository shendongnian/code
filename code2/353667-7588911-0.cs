    public class UsersController : Controller 
    { 
     
        static List<Users> users = GetSeededData(); 
     
        protected List<Users>()
        {
            List<Users> results = new List<Users>();
            results.Add(new Users() { UserName = "User1", CustomerID = "1"});
            results.Add(new Users() { UserName = "User2", CustomerID = "2"});
            results.Add(new Users() { UserName = "User3", CustomerID = "3"});
        }
        // 
        // GET: /Users/ 
     
        public ActionResult Index() 
        { 
            return View(users); 
        } 
     
        // 
        // GET: /Users/Details/5 
     
        public ActionResult Details(Users u) 
        { 
            return View(u); 
        } 
     
    } 
