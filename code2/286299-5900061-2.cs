    public class UserController : Controller
    {
        // create your own User class with as many properties as you need
        protected User user { get; set; }
    
        public UserController()
        {
            user = // get user from db, wherever
        }
    }
