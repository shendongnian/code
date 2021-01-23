    public class UserRegistrar {
        public void Register(User user, IUserRegistry userRegistry) {...}
    }
    
    public class MyApplicationClient : IUserRegistry {}
    
    public IUserRegistry {
        // Add, Remove, IsRegistered
    }
