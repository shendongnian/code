    [HttpPost]
    public ActionResult Create(ProductEditModel model)
    {
        if (!ModelState.IsValid)
        {
            // manually populate Categories again if validation failed
            model.Categories = Repository.GetCategories();
            return View(model);
        }
        // convert the model to the actual entity
        var product = Mapper.Map(model, new Product());
        Database.Save(product);
        // I would recommend you to redirect here
        return RedirectToAction("Success");
    }
