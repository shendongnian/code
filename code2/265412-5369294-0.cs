    public class User
    {
        public int Id { get; set; }
        ...
        public Foo Foo { get; set; }
        public Team Team { get; set; }
        public UserStuff UserStuff { get; set; }
    }
    public class Team
    {
        public int Id { get; set; }
        ...
        public ICollection<User> Users { get; set; }
    }
    public class Foo
    {
        public int Id { get; set; }
        ...
    }
    public class UserStuff
    {
        public int Id { get; set; }
        ...
    }
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Foo> Foos { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserStuff> UserStuff { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasRequired(u => u.Team)
                .WithMany(t => t.Users);
            modelBuilder.Entity<User>()
                .HasOptional(u => u.Foo)
                .WithRequired();
            modelBuilder.Entity<User>()
                .HasRequired(u => u.UserStuff)
                .WithRequiredPrincipal();
        }
    }
