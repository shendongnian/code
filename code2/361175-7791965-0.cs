    protected void Page_Load(object sender, System.EventArgs e)
    {
        System.Web.UI.WebControls.Login login = LoginArea.FindControl("LoginForm");
    
        TextBox txt = login.FindControl("UserName");
    
        Page.SetFocus(txt);
    
    }
