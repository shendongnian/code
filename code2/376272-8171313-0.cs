    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recording>()
                .HasRequired(r => r.RecordingLocation)
                .WithMany()
                .HasForeignKey(f => f.RecordingLocationId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Recording>()
                .HasRequired(r => r.EditingLocation)
                .WithMany()
                .HasForeignKey(f => f.EditingLocationId)
                .WillCascadeOnDelete(false);
        }
    }
