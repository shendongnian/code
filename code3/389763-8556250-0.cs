    // Composition root of your application
    void Main()
    {
        // Only instance of user we will ever create
        var user = new User();
    
    	var instance = new MyClass(user);
    }
    
    public interface IUser
    {
        string Name { get; set; }
    }
    
    public class User: IUser
    {
        public string Name { get; set; }
    }
    
    public class MyClass
    {
        public MyClass(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            
            _user = user;
        }
        
        private readonly IUser _user;
    }
