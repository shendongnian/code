    protected void Application_AcquireRequestState()
    {
      string userIp = HttpContext.Current.Request.UserHostAddress;
    
      if (Session["ipadress"] != null)
      {
        string originalUserIp = Session["ipadress"].ToString();
        if (originalUserIp != userIp)
        {
          Response.Redirect("sessioninactive.aspx");
        }
      }
    }
