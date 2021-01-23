    public ActionResult Index()
    {
        // display master view
    }
    
    [RequiresRouteValues("id")]
    public ActionResult Index(int id)
    {
        // display details view
    }
