    public class User : BaseEntity
    {
        private readonly IdentityUser<Guid> _identityUser;
        public string FullName { get; set; }
       
        public string UserName
        {
            get { return _identityUser.UserName; }
            set { _identityUser.UserName = value; }
        }
        public string Id
        {
            get { return _identityUser.Id; }
            set { _identityUser.Id = value ; } 
        }
        // ... etc.
        
        public User(IdentityUser<Guid> identityUser)
        {
            _identityUser = identityUser;
        }
    }
