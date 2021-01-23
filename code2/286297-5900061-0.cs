    public class UserController : Controller
    {
        protected User user { get; set; }
    
        public UserController()
        {
            user = // get user from db, wherever
        }
    }
