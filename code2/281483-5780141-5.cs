    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(Login1.UserName, "Admin"))
        {
             Response.Redirect("~/Admin/Default.aspx");
        }
        else if (Roles.IsUserInRole(Login1.UserName, "Examiner"))
        {
             Response.Redirect("~/Examiner/Default.aspx");
        }
        else
        {
             Response.Redirect("~/Login.aspx");
        }
    }
