    public class User {
        private User _user;
        public User Associated 
        { 
            get
            {
                if (_user == null)
                    _user = new User();
                return _user;
            }
        }
    }
