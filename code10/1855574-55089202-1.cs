    foreach (var property in navigations)
    {
        var propertyName = property.GetPropertyAccess().Name;
        await dbEntry.Collection(propertyName).LoadAsync();
        // this line specifically might need some changes
        // as it may give you ICollection<SomeType>
        var currentCollectionType = property.GetPropertyAccess().PropertyType;
        var deletedEntities = _dbContext.ChangeTracker
            .Entries
            .Where(x => x.EntityState == EntityState.Deleted && x.GetType() == currentCollectionType)
            .Select(x => (BaseEntity)x.Id)
            .ToArray();
        List<BaseEntity> dbChilds = dbEntry.Collection(propertyName).CurrentValue.Cast<BaseEntity>().ToList();
        foreach (BaseEntity child in dbChilds)
        {
            if (child.Id == 0)
            {
                _dbContext.Entry(child).State = EntityState.Added;
            }
            if (deletedEntities.Contains(child.Id))
            {
                _dbContext.Entry(child).State = EntityState.Deleted;
            }
            else
            {
                _dbContext.Entry(child).State = EntityState.Modified;
            }
        }
    }
