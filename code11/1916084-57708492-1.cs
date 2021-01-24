    if (User.Identity.IsAuthenticated)
    {
       if (!string.isNullOrEmpty(Request.QueryString["ReturnUrl"])
       {
          Response.Redirect("UnauthorizedAccess.aspx");
       }
       else
       {
          Response.Redirect("Dashboard.aspx");
       }
       StatusText.Text = string.Format("Hello {0}!!", 
       User.Identity.GetUserName());
       LoginStatus.Visible = true;
       LogoutButton.Visible = true;       
    }
    else
    {
       LoginForm.Visible = true;       
    }
