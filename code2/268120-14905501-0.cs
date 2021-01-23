    public class User: Entity
    {
        private string _openid;
        private string _email;
        private string _username;
        private int roleid;
        
        // needed for mapping
        protected User() { }
        // your normal constructor
        public User(string openid)
        {
            Validator.NotNull(string openid, "openid is required.");
            _openid = openid;
        }
        public string Email
        {
            get { return _email; }
        }
        public string Username
        {
            get { return _username; }
        }
        public string Openid
        {
            get { return _openid; }
        }
        
       // Here are some methods
       // ... 
    }
