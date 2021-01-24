    public ActionResult GetLaySimulation()
    {
        var ids = HttpContext.Request.QueryString["projectIDs"];
        int[] projectIDs = JsonConvert.DeserializeObject<int[]>(ids);
        // Code....
    }    
