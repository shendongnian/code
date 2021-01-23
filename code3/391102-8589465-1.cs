    public ActionResult Test(DateTime viewDate)
    {
        ViewBag.Date = viewDate;
        return View("Index");
    }
