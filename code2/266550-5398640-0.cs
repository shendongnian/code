    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set;}
    
        private ICollection<User> _users;
        public ICollection<User> Users
        {
            get
            {
                return _users ?? (_users = new HashSet<User>());
            }
            set
            {
                _users = value;
            }
        }
    }
