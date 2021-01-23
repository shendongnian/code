    public class UserService : IUserService
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                CustomPrincipal user = HttpContext.Current.User as CustomPrincipal;
    
                if (user == null)
                    return GuestUser; // Just some default user object
    
                return user;
            }
        }
    }
