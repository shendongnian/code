    public ActionResult Create(Booking item)
    {
    	TempData["data"] = JsonConvert.SerializeObject(MyModel);
    	return RedirectToAction("Details", new { id = 1 });
    }
