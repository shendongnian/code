    public class MockRepository<TUser> where TUser : User
    {
        private List<User> _users = new List<TUser>() { ... };
    
        public User this[int index]
        {
            get { return _users.First(x => x.Id == index); }
        }
    }
