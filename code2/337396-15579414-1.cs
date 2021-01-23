    public void ForceLogOut(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut(); // since I use Form authentication
        Session.Abandon();
    }
