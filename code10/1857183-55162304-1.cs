    [HttpPost]
    public ActionResult Save(EventViewModel walkEvent)
    {
        // Now here you have to convert EventViewModel data to Event before inserting.
        _context.Event.Add(walkEvent);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
