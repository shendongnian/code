    // SiteVisits method only
    public ActionResult SiteVisits(string id)
    {
        // Get the data for the UserHostAddress
        list = Repository.GetTheDataInListForm(id);
        return View(list);
    }
