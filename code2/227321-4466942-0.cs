    protected void Application_EndRequest(object sender, EventArgs e)
    {
        if (Response.RedirectLocation != null && Response.RedirectLocation.Contains("ReturnUrl"))
        {
            // change redirect URI
        }
    }
