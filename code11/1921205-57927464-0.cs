    public class CurrentUser : ICurrentUser
    {
        public User GetUserDetails()
        {
            var user = new User();
            try
            {
                var identity = ClaimsPrincipal.Current.Identities.First();
                user.Username = identity.Claims.First(c => c.Type == "Username").Value;
                user.Role = identity.Claims.First(c => c.Type == "Role").Value;
                user.LoggedIn = identity.Claims.First(c => c.Type == "LoggedIn").Value;
                return user;
            }
            catch (Exception)
            {
                return user;
            }
        }
    }
