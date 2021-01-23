    public class UserPerRequest
    {
        /// <summary>
        /// Returns the result of Membership.GetUser(), but will cache the results within the
        /// current request so it's only called once per request.
        /// </summary>
        public static MembershipUser Current
        {
            get
            {
                const string key = "UserPerRequest";
                if (HttpContext.Current.Items[key] == null)
                    HttpContext.Current.Items[key] = Membership.GetUser();
    
                return (MembershipUser)HttpContext.Current.Items[key];
            }
        }
    }
