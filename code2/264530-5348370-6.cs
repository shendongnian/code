    public ActionResult MyActionResult(int id)
    {
       MyViewModel mdl = new MyViewModel();
       mdl.Myregistration = new Registration();
       mdl.MyTable = //code to populate table
       return View(mdl);
    }
