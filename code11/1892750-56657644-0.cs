    [HttpPost]
    public IActionResult Index(int id)
    {
        var name = _db.MyDB.Where(p => p.id == id).FirstOrDefault();
        return RedirectToAction(nameof(Jobs), new { id, name });
    }
    
    [HttpGet]
    public IActionResult Jobs(string name, int id)
    {
        var allDetails = _db.MyDB.Where(p => p.id == id).FirstOrDefault();
        return View(allDetails);
    }
