    public void UpdateRow(T entity)
    {
        _objectSet.Attach(entity);
        _context.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
        _context.SaveChanges();
    }
