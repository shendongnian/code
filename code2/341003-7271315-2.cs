    public void AttachEntity(object entity)
    {
        baseContext = _context;
        base.AttachEntity(entity);
    }
    public void DetachApplication(Application app)
    {
        _context.Entry(app).State = EntityState.Detached;
        _context.SaveChanges();
    }
