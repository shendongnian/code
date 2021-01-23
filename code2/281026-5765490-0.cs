    if (!String.IsNullOrEmpty(Session["UserID"]))
    {
        HP_User.Text = "New User";
        HP_Login.Text = "login";
    }
    else
    {
        HP_User.Text = "welcome ." + Session["UserID"].ToString() ;
        HP_Out.Visible = true;
        HP_Login.Visible = false;
    }
