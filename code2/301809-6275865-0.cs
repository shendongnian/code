    public class UserGroup
    {
        private List<User> _Users;
        public ReadOnlyCollection Users
        {
            get { return _Users.AsReadOnly (); }
        }
        public void AddUser (User User)
        {
            // Perform your business logic here inside the object itself
            _Users.Add (User);
        }
        public UserGroup ()
            : this (null)
        { }
        public UserGroup (List<User> Users)
        {
            _Users = Users ?? new List<Users> ();
        }
    }
