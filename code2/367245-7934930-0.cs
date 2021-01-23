    public class MyContext : DbContext
    {
        // ... your DbSets
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasRequired(u => u.user_profile)
                .WithRequiredPrincipal();
        }
    }
