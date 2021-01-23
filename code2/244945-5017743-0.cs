    public class YourClass
    {
        private readonly UserProvider _userProvider;
        public TestedClass(UserProvider userProvider)
        {
            _userProvider = userProvider;
        }
        public void Create(string email, int id)
         {
            User user = _userProvider.GetUser(email, PermissionTypes.Add, id); // mock this out. and return a mocked user.
            if (user != null)
            {
                // check permission
                var  clearence = GetPermissions(user, PermissionTypes.Add, id);
                // some other stuff
    
            }
         }        
    }
    public class UserProvider
    {
        public User GetUser(string email, PermissionTypes.Add, id)
        {
            return Repo.GetUserByEmail(email);
        }
    }
