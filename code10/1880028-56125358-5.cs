    public async Task<Entity> GetEntity(int id)
    {
        using (var context = _contextFactory.Create())
        {
            return await context.Entities.FindAsync(id);
        }
    }
