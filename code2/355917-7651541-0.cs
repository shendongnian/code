    public ActionResult SaveText(SaveTextViewModel model)
    {
        if( !ModelState.IsValid )
        {
            // a validation error occurred
            Response.AppendHeader("X-Error", "true");
            return PartialView("SaveTextPartial", model);
        }
    
        repository.SaveText(...);
    
        return PartialView("SaveTextPartial");
    }
