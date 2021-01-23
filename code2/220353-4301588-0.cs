    public class EntityFactory
    {
        public EntityFactory(Func<User> userFactory) { /* ... */ }
    
        public User InstantiateUser()
        {
            return userFactory.Invoke();
        }
    }
