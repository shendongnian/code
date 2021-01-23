    public ActionResult Visit()
    {
        int visit = 0;
    
        if (base.IsLoggedIn() == true)
        {
            visit++;
            return PartialView();
        }
        else
        {
            return RedirectToAction("ACTION_NAME_GOES_HERE");
        }
    }
