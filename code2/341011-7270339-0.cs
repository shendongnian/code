    [HttpPost]
    public ActionResult Update(UpdateViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            // the surface validation on our view model failed => redisplay the view so
            // that the user can fix errors
            return View(viewModel);
        }
    
        // at this stage the view model is valid => we can map it back to a domain model
        // I use AutoMapper for this:
        var domainModel = Mapper.Map<UpdateViewModel, DomainViewModel>();
    
        // then we pass the domain model to the service layer for processing:
        string error;
        if (!_service.Update(domainModel, out error))
        {
            // something wrong happened on the service layer
            ModelState.AddModelError("key", error);
            return View(viewModel);
        }
    
        // everything went fine
        return RedirectToAction("Success");
    }
