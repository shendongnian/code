    public class BaseClass
    {
        public BaseClass(string userManager)
        {
            UserManager = userManager;
        }
        public string UserManager { get; }
    }
    public class SubClass : BaseClass
    {
    }
