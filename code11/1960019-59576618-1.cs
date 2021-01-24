    public ActionResult Create()
    {
       var selectList = db.Person.Select(x => new SelectListItem { Text = $"{x.Firstname} - {x.Lastname}", Value = x.Id.ToString()});
       ViewBag.IdOsoby = new SelectList(selectList, "Value", "Text");
       return View();
    }
