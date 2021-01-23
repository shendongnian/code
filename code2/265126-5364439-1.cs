    protected override void OnLoad(EventArgs e)
    {
      if (User.Identity.IsAuthenticated == false) { Response.Redirect("~/Account/login.aspx?ReturnUrl=/admin"); };
      if (!(User.IsInRole("admin") || User.IsInRole("super user"))) { Response.Redirect("/"); };
        
      base.OnLoad(e);
    }
