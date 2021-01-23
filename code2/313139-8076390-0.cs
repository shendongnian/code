    private IRepository repository;
    public ActionResult Edit(TEntity entity)
    {
        if (ModelState.IsValid)
        {
            repository.Update(entity);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(entity);
    }
