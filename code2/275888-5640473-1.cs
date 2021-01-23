    public ActionResult Create()
    {
        try
        {
            ViewBag.Organizations = db.Organizations.OrderBy(o => o.Title).ToList();
    
            var organization = new Organization();
            return View(organization);
        }
        catch (Exception e)
        {
            ViewData["error"] = string.Concat(e.Message, " ", e.StackTrace);
            return RedirectToAction("Index");
        }
    } 
