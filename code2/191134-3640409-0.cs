    public interface IAuditable
    {
        User CreatedBy { get; set; }
        DateTime? DateCreated { get; set; }
        User ModifiedBy { get; set; }
        DateTime? DateModified { get; set; }
        User DeletedBy { get; set; }
        DateTime? DateDeleted { get; set; }
    }
    // Classes that implement the IAuditable here.
    
    public class User : EntityObject
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        // etc...
    }
    partial class MyDbModel
    {
        public override int SaveChanges(SaveOptions options)
        {
            // Search all added, modified or deleted entities.
            var entries = this.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Deleted);
            foreach (var entry in entries)
            {
                var auditable = entry.Entity as IAuditable;
                if (auditable != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        auditable.CreatedBy = null; // TODO - Get current user.
                        auditable.DateCreated = DateTime.Now;
                        auditable.ModifiedBy = null; // TODO - Same as CreatedBy?
                        auditable.DateModified = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        auditable.ModifiedBy = null; // TODO - Get current user.
                        auditable.DateModified = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        auditable.DeletedBy = null; // TODO - Get current user.
                        auditable.DateDeleted = DateTime.Now;
                    }
                }
            }
            return base.SaveChanges(options);
        }
    }
