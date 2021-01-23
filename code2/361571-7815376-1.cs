    [HttpGet]
    public ActionResult Horses()
    {
        var model = new HorseViewModel { Horses = db.Genders.ToList() }
    
        return View(model);
    }
