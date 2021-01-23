    public class StackOverflowContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().MapHierarchy(p => new
            {
                p.UserId,
                p.Firstname,
                p.SurName,
            })
            .ToTable("Person");
            modelBuilder.Entity<User>().MapHierarchy(u => new
            {
                u.UserId,
                u.CreatedOn
            })
            .ToTable("User");
        }
    }
