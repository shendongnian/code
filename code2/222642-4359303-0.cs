    [HttpPost]
    public ActionResult Create(RegisterViewModel newCustomer)
    {
         if (ModelState.IsValid)
         {
             // code to save to database, redirect to other page
         }
         else
         {
             return View(newCustomer);
         }
    }
