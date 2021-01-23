    if (!HttpContext.Current.User.Identity.IsAuthenticated) {
       Login lg = (WebControls.Login)LoginView1.FindControl("Login2");
       TextBox tb = (TextBox)lg.FindControl("UserName");
       tb.Focus();
    }
