    public abstract class User
    {
        protected string _username;
        protected string _password;
        public user(string username, string password)
        {
            this._username = username;
            this._password = password;
        }
        public string Username
        {
            get 
            {
                return _username;
            }
            set
            {
                 _username = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
    }
