    public void AttachEntity(object entity)
    {
        baseContext = _context;
        base.AttachEntity(entity);
    }
    public void DetachUser(User user)
    {
        _context.Entry(user).State = EntityState.Detached;
        _context.SaveChanges();
    }
