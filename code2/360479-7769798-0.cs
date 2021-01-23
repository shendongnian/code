    if (!HttpContext.Current.User.Identity.IsAuthenticated) {
       Login lg = (Login)LoginView1.FindControl("Login1");
       TextBox tb = (TextBox)lg.FindControl("UserName");
       Label2.Text = tb.Text;
    }
