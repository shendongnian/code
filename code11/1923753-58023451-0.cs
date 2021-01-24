    [Route("{hash}/{eid}/{*filename}")]
    [HttpGet]
    public ActionResult File(string hash, string eid, string filename) 
    {
    }
    
    or 
    
    routes.MapRoute(
        "Upload",
        "file/{hash}/{eid}/{*filename}",
         new { controller = "Upload", action = "File", id = UrlParameter.Optional }
    );
