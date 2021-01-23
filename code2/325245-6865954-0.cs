    protected void btnLogin_Click(object sender, EventArgs e)
    {        
        if (LoggedIn)
        {
            FormsAuthentication.SetAuthCookie("blabla", true); 
            //Note: Request.QueryString["ReturnUrl"] = "/Default.aspx?bla=test";
    
             // This will get only the first instance of ReturnUrl
             var url = Request.Url.PathAndQuery.Substring(
                    Request.Url.PathAndQuery.IndexOf("ReturnUrl=") + ("ReturnUrl=").Length);
    
            Response.Redirect(url);
    
        }
    }
