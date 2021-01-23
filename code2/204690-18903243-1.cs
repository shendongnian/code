    public HttpSessionState GetSession()
    {
        //Check if current context exists
        if (HttpContext.Current != null)
        {
            return HttpContext.Current.Session;
        }
        else
        {
            return this.Session;
        }
    }
