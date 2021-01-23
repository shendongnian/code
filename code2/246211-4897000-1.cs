    [HttpPost]
    public ActionResult Create(Visitor visitor)
    {
        if (!ModelState.IsValid)
        {
            // There was a model error => redisplay the view so 
            // that the user can fix it
            return View();
        }
    
        // you don't really need those try/catch here
        // simply leave the exception propagate and the 
        // HandleError global exception filter
        // will render the ~/Shared/Error.cshtml view passing
        // the exception details
        visitorRepository.Add(visitor);
        visitorRepository.Save();                
        return RedirectToAction("Details", new { id = visitor.ID });
    }
