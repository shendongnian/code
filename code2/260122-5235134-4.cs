    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(Login1.UserName, "Admin"))
        {
             Response.Redirect("~/Admin/Default.aspx");
        }
        else if (Roles.IsUserInRole(Login1.UserName, "User"))
        {
             Response.Redirect("~/User/Default.aspx");
        }
        else if (Roles.IsUserInRole(Login1.UserName, "Viewer"))
        {
             Response.Redirect("~/Viewer/Default.aspx");
        }
        else
        {
             Response.Redirect("~/Login.aspx");
        }
    }
