    public abstract class User
    {
        protected string _username;
        protected string _password;
        public user(string username, string password)
        {
            this._username = username;
            this._password = password;
        }
        public string GetUsername()
        {
            return _username;
        }
        public string GetPassword()
        {
            return _password;
        }
    }
