    public ActionResult Create(T entity)
    {
        Repository.Add(entity);
        return RedirectToAction("View", typeof(T).Name, new { ID = entity.ID });
    }
