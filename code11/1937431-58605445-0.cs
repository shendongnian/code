    protected void btnLoginButton_Click(object sender, EventArgs e)
    {
        if (Membership.ValidateUser(UserName.Text, Password.Text))
        {
            WelcomeBackMessage.Text = User.Identity.Name.ToString();
            // Log the user into the site
            Response.Redirect("~/Index.aspx");
