    public Task<Entity> GetEntity(int id)
    {
        using (var context = _contextFactory.Create())
        {
            return context.Entities.FindAsync(id);
        }
    }
