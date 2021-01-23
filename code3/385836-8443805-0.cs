    [HttpPost]
    public virtual ActionResult Create(YourModel model)
    {
      if (!ModelState.IsValid)
        return View(model);
     
      try
      {
        var dbEntity = _repository.Get(model.Id);
        Mapper.Map(model, dbEntity);
        _repository.Save(dbEntity);
        return RedirectToAction("Details", new { id = model.Id });
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
        //log error here.
        return View(model);
      }
    }
