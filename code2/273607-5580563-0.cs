    public class Repository : IRepository
    {
        public bool RunningEagerLoading { get; set; } // false by default
        public ICollection<User> GetAllUsers()
        {
            using (var db = CreateContext())
            {
                try
                {
                    RunningEagerLoading = true;
                    return db.Users.Include(u => u.Roles).ToList();
                    // Materializing (by ToList()) is important here,
                    // deferred loading would not work
                }
                finally
                // to make sure RunningEagerLoading is reset even after exceptions
                {
                    RunningEagerLoading = false;
                }
            }
        }
        // ...
    }
    public class User
    {
        // ...
        public ICollection<Role> Roles
        {
            get
            {
                if (Repository.RunningEagerLoading)
                    return _roles; // Eager loading cares for creating collection
                else
                    return _roles ?? (_roles = Repository.GetRolesByUserId(UserId));
            }
            set { _roles = value; }
        }
        private ICollection<Role> _roles;
        public IRepository Repository { private get; set; }
    }
