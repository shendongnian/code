    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
        }
        //other settings
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((BaseEntity)entry.Entity).AddedDate = DateTime.Now;
                        ((BaseEntity)entry.Entity).LastModified = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        ((BaseEntity)entry.Entity).LastModified = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
