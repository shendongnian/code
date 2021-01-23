    public class YourContext : DbContext
    {
        protected override void OnModelCreating( DbModelBuilder dbModelBuilder )
        {
            base.OnModelCreating( dbModelBuilder );
            var config = dbModelBuilder.Entity<SomeEntity>();
            config.Property(e => e.SomeEntityID).HasDatabaseGeneratedOption( DatabaseGeneratedOption.None);
        }
    }
