    public ActionResult Visit()
    {
        int visit = 0;
    
        if (base.IsLoggedIn())
        {
            visit++;
            // whatever else needs to be done
            return PartialView();
        }
        else
        {
            // Note that this could be done using the Authorize ActionFilter, using
            // an overriden Authorize ActionFilter, or by overriding OnAuthorize().
            if (!base.IsLoggedIn())
                return new HttpUnauthorizedResult();
        }
    }
