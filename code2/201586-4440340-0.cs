    [HttpPost]
    public virtual ActionResult Create(MyViewModel vm)
    {            
        if (ModelState.IsValid)
        {
            // do some work
            return this.CreateSuccess();
        }
        else
        {
            return View(vm);
        }
    }
    [NonAction]
    public virtual ActionResult CreateSuccess()
    {
        // do what's needed 
    }
