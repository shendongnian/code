        string userName = string.Empty;
       if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
        System.Web.Security.MembershipUser usr = Membership.GetUser();
         if (usr != null)
         {  
         userName = usr.UserName;
        }
        }
