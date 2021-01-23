    if (!this.IsPostBack)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(Request.RawUrl);
        }
    }
