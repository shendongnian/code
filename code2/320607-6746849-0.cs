    public class myMembershipProvider : System.Web.Security.SqlMembershipProvider
    {
    public override int MaxInvalidPasswordAttempts
    {
        get
        {
            //Check to the role of the user....and pass back the attempts allowed for them
            if (HttpContext.Current.User.IsInRole(Admin))
            {
                return 9999; whatever...
            }
            return base.MaxInvalidPasswordAttempts;
        }
    }
    }
