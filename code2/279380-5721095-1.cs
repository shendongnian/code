    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                        .HasMany(u => u.Groups)
                        .WithMany(g => g.Members);
            modelBuilder.Entity<User>()
                        .HasMany(u => u.OwnedGroups)
                        .WithRequired(g => g.Owner)
                        .WillCascadeOnDelete(false);
        }
    }
