    public class UserProvider : IUserProvider 
    {
        // interface method
        public User GetUser() 
        {
            // you obviously don't want a page dependency here but ok...
            return GetUserFromPage();
        }
    }
