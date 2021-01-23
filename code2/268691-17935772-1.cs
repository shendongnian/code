    protected void Application_BeginRequest(Object source, EventArgs e)
    {
      if (!Context.Request.IsSecureConnection && 
          !Request.Url.Host.Contains("localhost") && 
          Request.Url.AbsolutePath.Contains("SGAccount/Login"))
      {
          Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
      }
    }
