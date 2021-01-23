    public partial class MyEntities : ObjectContext
    {
        public override int SaveChanges(SaveOptions options)
        {
            this.DetectChanges();
            foreach (var insert in this.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added))
            {
                if (insert.Entity.HasProperty("DateCreated"))
                    insert.Entity.GetType().GetProperty("DateCreated").SetValue(insert.Entity, DateTime.UtcNow, null);
                if (insert.Entity.HasProperty("LastModified"))
                    insert.Entity.GetType().GetProperty("LastModified").SetValue(insert.Entity, DateTime.UtcNow, null);
            }
            foreach (var update in this.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified))
            {
                if (update.Entity.HasProperty("LastModified"))
                    update.Entity.GetType().GetProperty("LastModified").SetValue(update.Entity, DateTime.UtcNow, null);
            }
            return base.SaveChanges(options);
        }
    }
