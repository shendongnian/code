    public class UsersController : Controller 
    { 
     
        // static List<Users> users = GetSeededData(); - 
        // don't store a list locally, it isn't necessary if you have a database
        // consider holding the context instead perhaps?
        protected MyContext context = new MyContext();
        // 
        // GET: /Users/ 
     
        public ActionResult Index() 
        { 
            return View(context.users.ToList()); 
        } 
     
        // 
        // GET: /Users/Details/5 
     
        public ActionResult Details(int userId) 
        { 
            return View(context.Users.SingleOrDefault(x => x.UserId.Equals(userId)); 
        } 
     
    } 
