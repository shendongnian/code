    public class MyContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Application>()
               .HasOptional(a => a.SubForm)
               .WithRequired(s => s.Application);
        }
     }
