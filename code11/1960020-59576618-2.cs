    public ActionResult Create()
    {
       ViewBag.IdOsoby = new SelectList(db.Person.ToList(), "Id", "FullName");
       return View();
    }
