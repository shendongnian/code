    [HttpPost]
    public ActionResult Create()
    {
        Visitor visitor = new Visitor();
        if (!TryUpdateModel(visitor))
        {
            // There was a model error => redisplay the view so 
            // that the user can fix it
            return View();
        }
    
        try
        {
            visitorRepository.Add(visitor);
            visitorRepository.Save();                
        }
        catch(Exception e)
        {
            var exMsg = e.Message;
            return View("Exception");
        }  
        return RedirectToAction("Details", new { id = visitor.ID });
    }
