    public ActionResult Edit()
    {
      return View(new ParentChildViewModel());
    }
    
    [HttpPost]
    public ActionResult Edit(ParentChildViewModel data)
    {
      // Save your objects
    }
