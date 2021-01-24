    [Route("i/{id}/{name:slugify}", Name = "NewDetails")]
    public IActionResult Info([FromRoute]InfoVM model)
    {
        // do something with the model before passing it to the view
    
        return View(model);
    }
