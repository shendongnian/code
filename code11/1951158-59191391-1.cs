    public void CheckPermission()
    {
        var userPage = GetUserPage(User.Identity.Name);
        if (string.IsNullOrWhiteSpace(userPage))
        {
            Response.Redirect("/NotAllowed");
        }
        if (Request.RawUrl != userPage)
        {
            Response.Redirect(userPage);
        }
    }
