    [Authorize]
    public ActionResult Foo()
    {
        // fetch the connected user from the authentication cookie
        string username = User.Identity.Name; 
        // query the datastore to retrieve additional user information
        var userInfo = Membership.Provider.GetUser(username, false);
        string email = userInfo.Email;
        string comment = userInfo.Comment;
        return View();
    }
