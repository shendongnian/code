    [HttpPost]
    public ActionResult DorView(Dates dates)
    {
        if (ModelState.IsValid)
        {
            // do something with dates.FromDate and dates.ToDate
    
            return Json(dates);
        }
    
        return Json(dates);
    }
