public override int SaveChanges()
{
    ChangeTracker.DetectChanges();
    var entityEntries = ChangeTracker.Entries(); //null
    //var entityEntries = ChangeTracker.Entries<IEntity>(); this is null, too
    //var entityEntries = ChangeTracker.Entries().Where(entity => entity is IEntity); I tried to uses this, entityEntries still null
    foreach (var entity in entityEntries)
    {
        if (entity is IEntity autoEntry)// <- Problem here, since enity never be IEntity type. 
        //Should change to entity.Entity is IEntity autoEntry
        {
            if (entity.State == EntityState.Added)
            {
                autoEntry.CreateDate = DateTime.Now;
                autoEntry.UpdateDate = DateTime.Now;
            }
            else
            {
                autoEntry.UpdateDate = DateTime.Now;
            }
        }
    }
    return base.SaveChanges();
}
I still don't understand why `entityEntries = ChangeTracker.Entries<IEntity>();` always null whenever I add watch it. But my problem about auto datetime is solved.
