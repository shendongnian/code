    public static Guid getCurrentUserGUID(){
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            MembershipUser myObject;
            myObject = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            return (Guid)myObject.ProviderUserKey;
        }
        return Guid.Empty;       
    }
