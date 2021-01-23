    public virtual ActionResult Create(T entity) where T : IEntity
    {
        Repository.Add(entity);
        return RedirectToAction("View", this.ModelType, new { id = entity.Id });
    }
