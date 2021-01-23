    public ActionResult MyAction()
    {
       try
       {
          //call validation here
       }
       catch (RulesException ex)
       {
          ModelState.AddModelStateErrors(ex);
       }
    
       return View();
    }
