    public class UserContext
    {
        public string UserName { get; protected set; }
        public UserContext(string username)
        {
            UserName = username;
        }
    }
    public class AdminClient
    {
        UserContext User { get; set; }
        public AdminClient(UserContext currentUser)
        {
            User = currentUser;
        }
    }
    public class SecurityClient
    {
        public string Stuff { get { return "Hello World"; } }
        public SecurityClient()
        {
        }
    }
    class Program
    {
        public static T CreateClient<T>(params object[] constructorParams)
        {
            return (T)Activator.CreateInstance(typeof(T), constructorParams);   
        }
        static void Main(string[] args)
        {
            UserContext currentUser = new UserContext("BenAlabaster");
            AdminClient ac = CreateClient<AdminClient>(currentUser);
            SecurityClient sc = CreateClient<SecurityClient>();
        }
    }
