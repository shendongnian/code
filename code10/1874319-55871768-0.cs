    public static IList<AspNetUser> GetCurrentUsers(this HtmlHelper helper)
    {
        FulfillmentContext db = new FulfillmentContext();
        string username = HttpContext.Current.User.Identity.GetUserName();
    
        var currentUser = (from u in db.AspNetUsers
                        join ur in db.AspNetUserRoles on u.Id equals ur.UserId
                        join r in db.AspNetRoles on ur.RoleId equals r.Id
                        where u.UserName == username
                        select u).ToList();
    
        return currentUser;
    }
