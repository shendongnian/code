    if (User.Identity.IsAuthenticated)
    {
       Response.Redirect("Dashboard.aspx");
       StatusText.Text = string.Format("Hello {0}!!", 
       User.Identity.GetUserName());
       LoginStatus.Visible = true;
       LogoutButton.Visible = true;
    }
    else
    {
       LoginForm.Visible = true;
       Response.Redirect("UnauthorizedAccess.aspx");
    }
