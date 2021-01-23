    public class MyContext : DbContext
    {
        public override int SaveChanges()
        {
            ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;
            //Find all Entities that are Added/Modified that inherit from my EntityBase
            IEnumerable<ObjectStateEntry> objectStateEntries =
                from e in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                where
                    e.IsRelationship == false &&
                    e.Entity != null &&
                    typeof(EntityBase).IsAssignableFrom(e.Entity.GetType())
                select e;
            var currentTime = DateTime.Now;
            foreach (var entry in objectStateEntries)
            {
                var entityBase = entry.Entity as EntityBase;
                if (entry.State == EntityState.Added)
                {
                    entityBase.CreatedDate = currentTime;
                }
                entityBase.LastModifiedDate = currentTime;
            }
            return base.SaveChanges();
        }
    }
