    public bool IsLoggedIn {
      get { return (bool)Session["li"]; }
    }
    private HttpSessionState Session {
      get { return HttpContext.Current.Session; }
    }
