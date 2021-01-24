    [HttpPost]
    public ActionResult Save(EventViewModel walkEvent)
    {
        _context.Event.Add(walkEvent);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
