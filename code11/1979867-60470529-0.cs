    public class Manager
    {
        public User User {get;set;}
        public void DoSomething()
        {
            Console.WriteLine(User.Name);
        }
    }
    
    public abstract class BaseUser
    {
        public virtual string Name {get;}
    }
    
    public class ProxyUser : BaseUser
    {
        private User _realUser;
        public override string Name => _realUser.Name;
    }
    
    public class User : BaseUser
    {
        public override string Name {get;set;}
    }
