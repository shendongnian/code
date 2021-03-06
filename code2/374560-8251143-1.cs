    public class UserIdClientIdFactory : IClientIdFactory
    {
        public string CreateClientId(HttpContextBase context)
        {
            // get and return the UserId here, in my app it is stored
            // in a custom IIdentity object, but you get the idea
            MembershipUser user = Membership.GetUser();
            return user != null ? 
                 user.ProviderUserKey.ToString() : 
                 Guid.NewGuid().ToString();
        }
    }
