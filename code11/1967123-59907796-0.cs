public class MyContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryReletion> CategoryReletions { get; set; }
      protected override void OnModelCreating( DbModelBuilder modelBuilder )
      {
         modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
         modelBuilder.Entity<CategoryReletion>()
            .HasRequired( c => c.ParentId)
            .WithRequiredDependent()
            .WillCascadeOnDelete(false);
         modelBuilder.Entity<CategoryReletion>()
            .HasRequired( c => c.ChildId)
            .WithRequiredDependent()
            .WillCascadeOnDelete(false);
      }
}
