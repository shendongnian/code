    public ActionResult Index(string env)
    {
        string value = "default";
        if (env == "development")
        {
            value = "some value for dev";
        } 
        else if (env == "staging")
        {
            value = "some value for staging";
        }
        else if (env == "live")
        {
            value = "some value for live";
        }
        else
        {
            throw new Exception("Unknown environment");
        }
    
        ViewBag.Message = value;
        return View();
    }
