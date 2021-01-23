    var user = Membership.GetUser();
    if (user != null)
    {
       // user is logged in...
       Response.Write(user.UserName);
    }
