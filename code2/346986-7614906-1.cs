    void Application_BeginRequest(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Browser.IsMobileDevice)
        {
            Response.Redirect("http://m.mydomain.com" + Request.RawUrl);
        }
    }
