    public void SaveAll( IEnumerable<Entity> entities )
    {
        var ids = entities.Select(x => x.Id).ToList();
        var idsToRemove = context.Entities.Where(x => ids.Contains(x.Id)).Select(x => x.Id).ToList();
        var entitiesToInsert = entities.Where(x => !idsToRemove.Contains(x.Id));
        
        foreach(var entity in entitiesToInsert)
            context.Entities.AddObject(entity);
    }
