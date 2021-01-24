    protected void Session_Start()
    {
      string userIp = HttpContext.Current.Request.UserHostAddress;
      Session["ipadress"] = userIp;
    }
    
