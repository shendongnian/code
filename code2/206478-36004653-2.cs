    pubblic ActionResult yourDetails()
    {
         List<YourEntityName> PropertyName= new List<YourEntityName>();
         list = db.PropertyName.ToList();
         return View(list);
    }
