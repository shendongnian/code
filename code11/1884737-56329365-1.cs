        public class ExternalLoginProviderHelper
    {
        public static void LoginLocally(ClaimsPrincipal claimsPrincipal)
        {
            foreach(Claim claim in claimsPrincipal.Claims)
            {
                // extract the claim information here (ID, Email address, name (surname, given name) etc)
                // make repository call to save information to the datastore and get a local user ID
            }
        }
    }
