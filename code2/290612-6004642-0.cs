    [HttpPost]
    public ActionResult ActionMethod(MyObject myObj)
    {
      this.TempData["myObj"] = myObj;
    
      return this.View();
    }
